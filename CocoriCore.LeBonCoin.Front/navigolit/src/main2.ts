import { LitElement, html, property, customElement } from "lit-element";
import Navigo from "navigo/lib/navigo.es.js";

/*import {
  LitElement,
  html
} from 'lit-element.js'
import Navigo from 'navigo.es.js'
*/
console.log('Hello WebComponents')

@customElement('greeter-element')
export class GreeterElement extends LitElement {
  @property() firstName;

  @property() lastName;

  render() {
    return html`
        <h1>Hello ${this.firstName} ${this.lastName}</h1>
      `;
  }
}

@customElement('my-button')
class MyButton extends LitElement {
  render() {
    return html`
      <button>My Button</button>
    `
  }
}

@customElement('my-pagea')
class PageA extends LitElement {
  render() {
    return html`
      <div>
        Page A
        <div></div>
      </div>
    `
  }
}

@customElement('my-pageb')
class PageB extends LitElement {
  render() {
    return html`
      <div>
        Page B
        <div></div>
      </div>
    `
  }
}

@customElement('my-awesome-app')
class MyAwesomeApp extends LitElement {
  @property() route;

  constructor() {
    super()
    let router = new Navigo('/', true, '#!')
    router
      .on('pagea', () => {
        this.route = html`
          <my-pagea></my-pagea>
        `
      })
      .on('pageb', () => {
        this.route = html`
          <my-pageb></my-pageb>
        `
      })
      .on('*', () => {
        console.log('kevin')
        this.route = html`
          This is home.
        `
      })
    router.resolve()
  }
  render() {
    return html`
      <div>
        <h1>MyAwesomeApp</h1>
        <a href="#!/pagea">Page A</a> <a href="#!/pageb">Page B</a>
        <a href="#!/">Home</a> ${this.route}
      </div>
    `
  }
}

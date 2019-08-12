function fillParameterizedUrl(url: string, obj: object): string {
    var keys = Object.keys(obj);
    for (let k of keys) {
        url = url.replace("/:" + k + "/g", obj[k]);
    }
    return url;
}

abstract class Page {
    constructor() {
        document.addEventListener("DOMContentLoaded", async () => {
            await this.fetchAndFill('/api/' + location);
            await this.postInit();
        });
    }

    abstract postInit(): void;

    async fetchAndFill(url: string) {
        let response = await fetch(url,
            {
                headers: null,
                method: "GET",
                //mode: 'cors',
                //credentials: 'include'
            });

        let txt = await response.text();
        if (txt.length > 0) {
            var obj = JSON.parse(txt);
            var keys = Object.keys(obj);
            for (let k in keys) {
                this[k] = obj[k];
            }
        }
    }

    async send<T extends object>(submit: Submit<T>, body: T) {
        let url: string = fillParameterizedUrl(submit.parameterizedUrl, body);
        let fetchResponse = await fetch(url,
            {
                headers: null,
                method: submit.verb,
                //mode: 'cors',
                //credentials: 'include'
            });

        let txt = await fetchResponse.text();
        if (txt.length > 0) {
            var obj = JSON.parse(txt);
            var redirect = fillParameterizedUrl(submit.redirectParameterizedUrl, obj);
            location.href = redirect;
        }
    }
}

class Submit<T> {
    verb: string;
    parameterizedUrl: string;
    redirectParameterizedUrl: string;
}
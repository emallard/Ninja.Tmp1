// GENERATED CODE

class Users_Connexion_Post {
    email: string;
    password: string;
    passwordConfirmation: string;
}

abstract class PageConnexion extends Page {
    motDePasseOublie: string;
    submit: Submit<Users_Connexion_Post>;
}

// END OF GENERATED CODE


class PageConnexionImpl extends PageConnexion {

    constructor() {
        super();
    }

    async postInit() {
        document.getElementById("motDePasseOublie").setAttribute("href", this.motDePasseOublie);

        document.getElementById('submit').addEventListener('submit', async (evt) => {
            evt.preventDefault();
            await this.send(this.submit,
                {
                    email: (<HTMLInputElement>document.getElementById("email")).value,
                    password: (<HTMLInputElement>document.getElementById("password")).value,
                    passwordConfirmation: (<HTMLInputElement>document.getElementById("passwordConfirmation")).value
                });
            return false;
        })
    }
}

new PageConnexionImpl();
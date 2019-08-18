
// GENERATED CODE
/*
class Users_Connexion_Post {
    email: string;
    password: string;
    passwordConfirmation: string;
}

abstract class PageConnexion extends Page {
    motDePasseOublie: string;
    form: Form<Users_Connexion_Post>;
}
*/
// END OF GENERATED CODE


class Users_Connexion_PageImpl extends Users_Connexion_Page {

    constructor() {
        super();
    }

    async postInit() {
        document.getElementById("motDePasseOublie").setAttribute("href", this.MotDePasseOublie);

        document.getElementById('form').addEventListener('submit', async (evt) => {
            evt.preventDefault();
            /*
            await this.submit(this.Form,
                {
                    Email: (<HTMLInputElement>document.getElementById("email")).value,
                    Password: (<HTMLInputElement>document.getElementById("password")).value,
                    PasswordConfirmation: (<HTMLInputElement>document.getElementById("passwordConfirmation")).value
                });
            */
            return false;
        })
    }
}
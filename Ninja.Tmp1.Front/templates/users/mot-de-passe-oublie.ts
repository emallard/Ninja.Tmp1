
class Users_MotDePasseOublie_PageImpl extends Users_MotDePasseOublie_Page {

    constructor() {
        super();
    }

    async postInit() {
        document.getElementById('form').addEventListener('submit', async (evt) => {
            evt.preventDefault();
            /*
            await this.submit(this.Form,
                {
                    Email: (<HTMLInputElement>document.getElementById("email")).value
                });
            */
            return false;
        })
    }
}
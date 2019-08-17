var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
function fillParameterizedUrl(url, obj) {
    var keys = Object.keys(obj);
    for (let k of keys) {
        url = url.replace("/:" + k + "/g", obj[k]);
    }
    return url;
}
class Page {
    onInit() {
        return __awaiter(this, void 0, void 0, function* () {
            yield this.fetchAndFill(location.href.replace('#/', 'api/page/'));
            yield this.postInit();
        });
    }
    fetchAndFill(url) {
        return __awaiter(this, void 0, void 0, function* () {
            console.log('fetch page data : ' + url);
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");
            let response = yield fetch(url, {
                headers: myHeaders,
                method: "GET",
            });
            let txt = yield response.text();
            console.log('page data as text : ' + txt);
            if (txt.length > 0) {
                var obj = JSON.parse(txt);
                var keys = Object.keys(obj);
                for (let k of keys) {
                    console.log('page property : ' + k);
                    this[k] = obj[k];
                }
            }
            console.log(this);
        });
    }
    submit(submit, body) {
        return __awaiter(this, void 0, void 0, function* () {
            let url = fillParameterizedUrl(submit.parameterizedUrl, body);
            let fetchResponse = yield fetch(url, {
                headers: null,
                method: submit.method,
            });
            let txt = yield fetchResponse.text();
            if (txt.length > 0) {
                var obj = JSON.parse(txt);
                var redirect = fillParameterizedUrl(submit.redirectParameterizedUrl, obj);
                location.href = '#/' + redirect;
            }
        });
    }
}
class Form {
}
// GENERATED CODE
class Users_Connexion_Post {
}
class Users_Connexion_Page extends Page {
}
// END OF GENERATED CODE
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
    postInit() {
        return __awaiter(this, void 0, void 0, function* () {
            document.getElementById("motDePasseOublie").setAttribute("href", this.MotDePasseOublie);
            document.getElementById('form').addEventListener('submit', (evt) => __awaiter(this, void 0, void 0, function* () {
                console.log('Submit intercepté !');
                evt.preventDefault();
                /*
                await this.submit(this.Form,
                    {
                        Email: (<HTMLInputElement>document.getElementById("email")).value,
                        Password: (<HTMLInputElement>document.getElementById("password")).value,
                        PasswordConfirmation: (<HTMLInputElement>document.getElementById("passwordConfirmation")).value
                    });
                */
                console.log('Submit return false');
                return false;
            }));
        });
    }
}
//# sourceMappingURL=tsbuild.js.map
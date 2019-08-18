// GENERATED CODE

abstract class PageAccueil extends Page {
    connexion: string;
    inscription: string;
}

// END OF GENERATED CODE


class PageAccueilImpl extends PageAccueil {

    constructor() {
        super();
    }

    async postInit() {
        document.getElementById("connexion").setAttribute("href", this.connexion);
        document.getElementById("inscription").setAttribute("href", this.inscription);
    }
}

new PageAccueilImpl();
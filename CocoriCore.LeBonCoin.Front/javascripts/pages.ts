class Users_Connexion_POST {
    Email: String;
    Password: String;
}

class Users_Connexion_POSTResponse {
    Token: String;
    Redirect: string;
}

class Users_MotDePasseOublie_POST {
    Email: String;
}

class Users_MotDePasseOublie_POSTResponse {
    Redirect: string;
}

class MenuUtilisateur {
    Deconnexion: string;
    Connexion: string;
    Inscription: string;
}

abstract class Accueil_PAGE extends Page {
    PageUrl:string = '/api/';
    Connexion: string;
}

abstract class Users_Connexion_PAGE extends Page {
    PageUrl:string = '/api/users/connexion';
    MotDePasseOublie: string;
    Form: Form<Users_Connexion_POST, Users_Connexion_POSTResponse>;
}

abstract class Users_MotDePasseOublie_PAGE extends Page {
    PageUrl:string = '/api/users/mot-de-passe-oublie';
    Form: Form<Users_MotDePasseOublie_POST, Users_MotDePasseOublie_POSTResponse>;
}

abstract class Vendeur_Dashboard_PAGE extends Page {
    PageUrl:string = '/api/vendeur';
    MenuUtilisateur: MenuUtilisateur;
    Reunions: string;
}


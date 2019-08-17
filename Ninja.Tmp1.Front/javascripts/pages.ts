// GENERATED CODE

class Users_Connexion_Post {
    Email: string;
    Password: string;
    PasswordConfirmation: string;
}

abstract class Users_Connexion_Page extends Page {
    MotDePasseOublie: string;
    Form: Form<Users_Connexion_Post>;
}

class Users_MotDePasseOublie_Post {
    Email: string;
}

abstract class Users_MotDePasseOublie_Page extends Page {
    Form: Form<Users_MotDePasseOublie_Post>;
}

// END OF GENERATED CODE



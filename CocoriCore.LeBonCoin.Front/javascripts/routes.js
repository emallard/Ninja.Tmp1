function addRoutes(app) {
app.addPage("/", Accueil_PAGEComponent, "templates/Accueil_PAGEComponent.html");
app.addPage("/users/connexion", Users_Connexion_PAGEComponent, "templates/users/Users_Connexion_PAGEComponent.html");
app.addPage("/users/mot-de-passe-oublie", Users_MotDePasseOublie_PAGEComponent, "templates/users/Users_MotDePasseOublie_PAGEComponent.html");
app.addPage("/vendeur", Vendeur_Dashboard_PAGEComponent, "templates/vendeur/Vendeur_Dashboard_PAGEComponent.html");
}
function addRoutes(app) {
  app.addPage("users/connexion", Users_Connexion_PageImpl);
  app.addPage("users/mot-de-passe-oublie", Users_MotDePasseOublie_PageImpl);
}
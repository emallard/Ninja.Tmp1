## Creation de code métier réutilisable :

MessageBus : Recopier les fichiers du répertoire message => Donne une base pour travailler avec des handlers (Pas de dépendance Cocoricore)
Possibilité de rajouter des IQuery, des ICommand, etc...

Api : contient les messages et les handlers : possibilité de mettre des Links et des Submits

Test : contient un TestBase pour l'Injection et pour pouvoir récupérer un TestUser qui est le point de base pour parcourir l'Api
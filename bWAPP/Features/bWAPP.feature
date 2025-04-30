Feature: Tester les fonctionnalités de BWAPP

    Background: 
        Given L'utilisateur est sur la page de login
        When Il saisit "bee" dans le champ username
        And Il saisit "bug" dans le champ password
        And Il clique sur le bouton de connexion

    Scenario: L'utilisateur se connecte avec les bons identifiants
        Then Il est redirigé vers la page d'accueil sécurisée

    Scenario: L'utilisateur entre de mauvais identifiants
        Given L'utilisateur est sur la page de login
        When Il saisit "wrong" dans le champ username
        And Il saisit "credentials" dans le champ password
        And Il clique sur le bouton de connexion
        Then L'utilisateur est sur la page de login

    Scenario: L'utilisateur se déconnecte après s'être connecté
        When Il clique sur le lien de déconnexion
        And Il confirme la déconnexion dans la popup
        Then L'utilisateur est sur la page de login

    Scenario: L'utilisateur modifie le niveau de sécurité
        When Il navigue vers la page de configuration de sécurité
        And Il sélectionne le niveau high
        And Il clique sur le bouton de Set
        Then Le niveau de sécurité affiché est "high"
        
    Scenario: L'utilisateur change son mot de passe
        When Il clique sur le bouton de changement de mot de passe
        And Il entre "bug" comme ancien mot de passe
        And Il entre "newbug" comme nouveau mot de passe
        And Il confirme avec "newbug"
        And Il clique sur Change password
        Then Un message confirmant le changement de mot de passe est affiché

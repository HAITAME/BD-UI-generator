

# Générateur d'Interface de Base de Données

## Description

Ce projet est une application de gestion de bases de données MySQL développée en utilisant C# et .NET Framework. L'objectif principal de cette application est de fournir une interface conviviale et fonctionnelle pour interagir avec des bases de données MySQL. Elle propose des fonctionnalités telles que la création de tables, l'édition de données, l'exécution de requêtes SQL personnalisées, ainsi que l'exportation des données dans divers formats. De plus, elle offre la possibilité de visualiser l'état du serveur, des processus et des statistiques sur les requêtes.

## Table des Matières

1. [Introduction](#introduction)
2. [Technologies Utilisées](#technologies-utilisées)
3. [Fonctionnalités](#fonctionnalités)
4. [Installation](#installation)
5. [Utilisation](#utilisation)
6. [Captures d'écran](#captures-décran)

## Introduction <a name="introduction"></a>

Ce README fournit une vue d'ensemble de notre application de gestion de bases de données MySQL développée en C# avec .NET Framework. L'objectif principal de cette application est de fournir une interface conviviale et fonctionnelle pour interagir avec des bases de données MySQL, en offrant des fonctionnalités telles que la création de tables, l'édition de données, l'exécution de requêtes SQL personnalisées, l'exportation de données dans divers formats, et la visualisation de l'état du serveur et des statistiques sur les requêtes.

## Technologies Utilisées <a name="technologies-utilisées"></a>

- **Langage :** C#
- **Framework :** .NET Framework
- **Base de Données :** MySQL
- **Interface Utilisateur :** Windows Forms

### Description des Technologies

- **C# :** Langage de programmation polyvalent orienté objet utilisé pour développer l'ensemble de l'application.
- **.NET Framework :** Plateforme de développement logiciel de Microsoft qui fournit une large gamme de bibliothèques et de fonctionnalités pour les applications Windows.
- **MySQL :** Système de gestion de base de données relationnelle open source.
- **Windows Forms :** Bibliothèque de développement d'interface utilisateur pour les applications Windows basées sur .NET.

## Fonctionnalités <a name="fonctionnalités"></a>

### Authentification

- **Entrée des Détails de Connexion :**
  - Nom ou IP de l'hôte
  - Nom d'utilisateur
  - Mot de passe
  - Nom de la base de données
- **Validation des Informations :** Établissement de la connexion à la base de données MySQL avec les informations fournies.

### Interface Principale

- **Liste des Tables :** Affichage des tables de la base de données après l'authentification.
- **Éditer les Données :** Permet la modification des données individuelles dans les tables sélectionnées.
- **Fenêtres d'Exécution des Requêtes et d'Historique des Requêtes :**
  - **Exécution des Requêtes :** Exécution de requêtes SQL personnalisées (SELECT, INSERT, UPDATE, DELETE) et affichage des résultats.
  - **Historique des Requêtes :** Historique des requêtes exécutées pour un accès rapide.

### Navigation et Affichage des Données

- **Affichage des Données de la Table :**
  - **Parcourir :** Visualisation des données de la table sélectionnée.
  - **Structure :** Affichage détaillé de la structure de la table.
  - **Relations :** Affiche les tables en relation et leur contenu si des clés étrangères sont définies.
- **Ajout de Données :** Bouton "Ajouter" pour insérer de nouvelles données dans les tables.
- **Édition des Données :**
  - Double-clic sur une ligne pour éditer les données.
  - Validation des modifications avant la sauvegarde pour garantir l'intégrité des données.

### Menu Principal

- **Rafraîchir la Page :** Mise à jour des informations affichées.
- **Changer de Base de Données :** Sélection d'une autre base de données parmi celles disponibles.
- **Exportation des Données :** Exportation des données dans des formats comme Excel, PDF et CSV.
- **État du Serveur :** Visualisation de l'état du serveur, des processus et des statistiques sur les requêtes.
- **Créer une Nouvelle Table :** Interface pour créer de nouvelles tables dans la base de données.
- **Supprimer une Table :** Option pour supprimer une table existante.
- **Déconnexion :** Déconnexion de l'application et retour à la page d'authentification.

### Édition des Données dans les Tables

L'application permet aux utilisateurs d'éditer facilement les données individuelles dans les tables sélectionnées. Cette fonctionnalité inclut :

- **Visualisation et Sélection :** Affichage des enregistrements sous forme de vue tabulaire avec possibilité de sélectionner des enregistrements pour modification.
- **Modification Directe :** Double-clic sur une cellule pour entrer en mode édition et saisir une nouvelle valeur.
- **Validation :** Vérification des données modifiées pour assurer la conformité aux contraintes de la base de données avant la sauvegarde.
- **Gestion des Erreurs :** Affichage de messages d'erreur clairs en cas de problème lors de la modification des données.

## Installation <a name="installation"></a>

Pour installer et exécuter l'application sur votre machine locale, suivez ces étapes :

1. Clonez le référentiel GitHub sur votre machine locale :
   ```bash
   git clone https://github.com/votre-utilisateur/votre-projet.git
   ```
2. Ouvrez le projet dans Visual Studio.
3. Compilez le projet pour restaurer les packages NuGet nécessaires.
4. Configurez les paramètres de connexion à la base de données dans l'application.
5. Exécutez l'application depuis Visual Studio ou en lançant l'exécutable généré.

## Utilisation <a name="utilisation"></a>

### Connexion à la Base de Données

1. Lancez l'application.
2. Entrez le nom ou l'IP de l'hôte, le nom d'utilisateur, le mot de passe et le nom de la base de données.
3. Cliquez sur "Connecter" pour établir la connexion.

### Navigation dans l'Interface

1. Sélectionnez une table dans la liste déroulante pour afficher ses données.
2. Utilisez les boutons "Parcourir", "Structure" et "Relations" pour naviguer entre les différentes vues de la table.
3. Cliquez sur "Éditer" pour ouvrir la fenêtre d'édition des données de la table.

### Exécution de Requêtes SQL

1. Saisissez votre requête SQL dans la zone de texte dédiée.
2. Cliquez sur "Exécuter" pour exécuter la requête.
3. Les résultats s'afficheront dans le panneau principal ou dans des onglets distincts si plusieurs requêtes sont exécutées.

### Gestion de l'Historique

- **Affichage :** Consultez l'historique des requêtes exécutées dans la section "Historique".
- **Vider l'Historique :** Cliquez sur "Vider l'Historique" pour effacer toutes les entrées de l'historique.

### Exportation et État du Serveur

1. Utilisez les options d'exportation pour sauvegarder vos données au format souhaité (Excel, PDF, CSV).
2. Cliquez sur "État" pour afficher les informations sur l'état du serveur, les processus et les statistiques.

## Captures d'écran <a name="captures-décran"></a>
# 1.Interface de Connexion

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/cf96df2a-00fc-4fdf-b405-a200e8c75536)

# 2.Structure des Tables, Contenu et Relations
Pour chaque table listée, vous avez la possibilité de parcourir et visualiser les données contenues. Cela vous permet de voir les enregistrements existants et de naviguer facilement entre eux.


### Affichage de la Structure des Tables

Après avoir sélectionné une base de données et connecté l'application, vous pouvez visualiser la structure détaillée de chaque table disponible. Cela inclut les noms des colonnes, les types de données, les contraintes (comme les clés primaires et les clés étrangères) et d'autres propriétés pertinentes.

### Contenu des Tables

Pour chaque table listée, vous avez la possibilité de parcourir et visualiser les données contenues. Cela vous permet de voir les enregistrements existants et de naviguer facilement entre eux.

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/2785439a-5d7d-4b90-ae10-82cd824cf071)

### Affichage de la Structure des Tables

Après avoir sélectionné une base de données et connecté l'application, vous pouvez visualiser la structure détaillée de chaque table disponible. Cela inclut les noms des colonnes, les types de données, les contraintes (comme les clés primaires et les clés étrangères) et d'autres propriétés pertinentes.

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/7f7e33ab-182b-4917-8881-57100bccb9ce)

### Relations entre les Tables

L'application détecte automatiquement les relations entre les tables si des clés étrangères sont définies dans la base de données. Vous pouvez explorer ces relations pour comprendre comment différentes tables sont liées les unes aux autres.

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/f55c8467-0009-4f7e-928b-98adb8ef0bac)

# 3.Édition des Données

### Édition Directe des Enregistrements

En double-cliquant sur une ligne de la table affichée, une fenêtre d'édition s'ouvre, permettant à l'utilisateur de modifier les valeurs des champs. Cela offre une manière simple et directe de mettre à jour les données existantes.

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/cc310675-a1bf-441d-b0cb-071791fdddc4)




### Gestion Avancée des Enregistrements

En plus de l'édition directe, l'application propose une interface pour gérer les enregistrements de manière plus avancée. Vous pouvez naviguer entre les enregistrements à l'aide des boutons "Précédent" et "Suivant", sauvegarder les modifications apportées, ou même supprimer des enregistrements en toute simplicité.


![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/3b7f1e9f-69b0-4504-b35d-4ac994d631da)


# 4.Ajout de Données
L'application offre une interface intuitive pour ajouter de nouvelles données aux tables existantes.

### Interface d'Ajout de Données

Les utilisateurs peuvent facilement naviguer vers la table désirée et utiliser le formulaire d'ajout pour insérer de nouveaux enregistrements.

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/de85d641-7d40-4173-beb9-206c9d1e0d4f)

### Processus d'Ajout

1. **Sélection de la Table :** Choisissez la table depuis la liste déroulante des tables disponibles.
   
2. **Formulaire d'Ajout :** Saisissez les valeurs pour chaque champ requis dans le formulaire dédié.

3. **Enregistrement :** Validez et enregistrez les données en cliquant sur le bouton "Enregistrer".

#  5.Exécution de Requêtes SQL
### Exécution d'une Seule Requête

L'application permet aux utilisateurs d'exécuter des requêtes SQL personnalisées directement depuis l'interface. Cette capture d'écran illustre l'exécution d'une seule requête SELECT pour récupérer des données spécifiques d'une table.

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/d2d20950-43e1-4177-abff-24e709beab11)


### Exécution de Plusieurs Requêtes

Les utilisateurs peuvent également exécuter plusieurs requêtes SQL en même temps à partir de l'interface. Cette capture d'écran montre l'exécution simultanée de trois requêtes : SELECT, INSERT et UPDATE, avec les résultats affichés pour chaque requête.

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/a98439e8-730c-4e29-99f2-518df119ccae)


![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/11867b8b-e355-465a-a415-682380bef084)

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/c29f6fef-2c01-4572-9115-ffa0580170d0)


# 6.Gestion de l'Historique

L'application conserve un historique des requêtes SQL récemment exécutées, ce qui permet aux utilisateurs de :

- **Consulter l'Historique :** Visualiser la liste des requêtes précédemment exécutées.
- **Réutiliser les Requêtes :** Sélectionner une requête dans l'historique pour la réutiliser facilement.
- **Éditer les Requêtes :** Double-cliquer sur une entrée de l'historique pour la réécrire ou l'éditer dans la zone de saisie de requêtes.
  
![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/b06fbb59-648c-46f5-bb06-01d221cb63c5)


# 7.Exportation des Données
![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/5fdeb5d7-7b3c-4722-8f39-bb62dc6b1e10)

L'application permet d'exporter les données de la base de données MySQL dans divers formats pour une utilisation ultérieure ou pour partager les informations avec d'autres outils. Les formats disponibles sont :

- **Exportation en Excel :** Exporter les données sous forme de fichier Excel (.xlsx).

  ![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/93ac2d24-27c4-4f38-b1dd-f7ca9f784877)

- **Exportation en PDF :** Exporter les données sous forme de fichier PDF (.pdf).
  ![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/d01658de-32cd-4ac8-81ac-fbea95ef5b0c)


- **Exportation en CSV :** Exporter les données sous forme de fichier CSV (.csv).
   ![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/0a4d420e-8190-40d9-aaa9-7ee2b3ccbe20)

Ces options d'exportation permettent aux utilisateurs de choisir le format qui convient le mieux à leurs besoins, qu'il s'agisse de partager des rapports, d'analyser les données avec d'autres logiciels, ou de conserver des copies locales des informations.

# 8.État du Serveur MySQL

Un tableau de bord intégré affiche l'état actuel du serveur MySQL, y compris les informations sur les processus en cours, la charge du serveur et les statistiques sur les requêtes. Cela permet aux administrateurs de surveiller efficacement la santé et les performances du serveur.

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/31e49763-2150-4b19-b17e-f28e319edf68)

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/e060236a-c3a3-47df-8372-d4f607a0c2a8)

![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/784a8534-bec5-4e63-aa2b-6f688faaff38)

# 9.Création de Nouvelle Table

Les utilisateurs peuvent créer de nouvelles tables dans la base de données MySQL à l'aide d'une interface intuitive. Ils peuvent spécifier les colonnes personnalisées avec des options telles que les clés primaires, les types de données et les contraintes.


![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/813a296e-b8e0-48ce-8fd4-40bf01449069)


# 10.Suppression de Table Existante

Cette fonctionnalité permet de supprimer facilement une table existante dans la base de données MySQL directement depuis l'interface utilisateur. Une confirmation est généralement demandée pour éviter les suppressions accidentelles.


![image](https://github.com/HAITAME/BD-UI-generator/assets/111463501/703607a3-926e-4d50-a181-2441d43e1165)







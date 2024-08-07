#  OP-P10-Microservices
> OpenClassrooms Projet 10 : Développez une solution en microservices pour votre client


## Informations Générales
Ce projet porte sur la gestion des patients par un organisateur, la prise de notes par un praticien et la détermination du risque de diabète chez un patient.

Sur le plan technique, l'objectif est de réaliser une application avec une architecture en microservices, d'utiliser une base de données noSQL pour les notes, et de s'intéresser au "Green Code".

Ce projet comporte 7 microservices :
 - Une api s'appelant Gestion-Patients
 - Une api s'appelant Gestion-Notes
 - Une api s'appelant Rapport-Diabete
 - Une gateway s'appelant Ocelot
 - Un base de données SQL Server
 - Une base de données MongoDB
 - Un application client angular

Ci-dessous vous pouvez retrouver un diagramme représentant l'architecture de l'application :
```mermaid
	graph TD;
	Ocelot[[Ocelot Gateway]]  -->  Gestion-Patients[Gestion-Patients API]
	Ocelot  -->  Rapport-Diabete[Rapport-Diabete API]
	Ocelot  -->  Gestion-Notes[Gestion-Notes API]
	Gestion-Patients  -->  SQL[(SQL Server)]
	Gestion-Notes  -->  MongoDB[(MongoDB)]
	Client[Angular-App Client]  <-->  Ocelot
```


## Technologies utilisées
- Angular 17.2.1
- Angular Material
- RxJS
- .NET  8.0
- Docker
- Entity Framework Core
- JWT
- Swashbuckle
- Serilog
- Sql Server
- MongoDB

## Prérequis 
Pour faire fonctionner le projet, vous devez au préalable avoir installer sur votre machine :
- Git : https://git-scm.com/
- Docker : https://www.docker.com/

## Installation
Avant toute chose, vérifier que Docker est lancé sur votre ordinateur.

1. Cloner le projet 
	```
	git clone --single-branch --branch dev https://github.com/AxekPhanor/OP-P10-Microservices.git
	```
2. Dans le répertoire du projet utiliser cette commande pour créer nos images et lancer nos conteneurs docker. 
	```
	docker compose up
	```
	Cela peut prendre plus au moins de temps selon votre connexion internet et les performances de votre machine.

## Utilisation
Une fois que vous avez installer le projet, nos conteneurs devrait tourner sur différent port en local.
Pour accéder au l'application client : http://localhost:4277/
Vous devrez normalement voir apparaitre une page de connexion (si ce n'est pas le cas vous pouvez y accéder à cette adresse http://localhost:4277/login)

Lors de la création de nos conteneurs, 3 comptes ont été créés, chacun ayant différents accès ou restrictions sur l'application.

**Le compte organisateur:** <br>
nom de compte : organizer <br>
mot de passe : 6yb64nOav4M?JmHzn <br>
Il possède le rôle organizer. <br>

**Le compte praticien :** <br>
nom de compte : practitioner <br>
mot de passe : 6yb64nOav4M?JmHzn <br>
Il possède le rôle practitioner.

**Le compte administrateur :** <br>
nom de compte : admin <br> 
mot de passe : 6yb64nOav4M?JmHzn <br>
Il possède les rôles organizer et practitioner.

Le rôle **organizer** vous permet de créer des patients, de modifier leurs informations personnelles, ou de les supprimer. Quant au rôle **practitioner**, vous pourrez accéder au dossier d'un patient, comprenant l'historique des notes, le risque de diabète du patient et vous aurez également la possibilité de créer des notes.

## Recommandations d'amélioration "Green"
- Implémentation d'un cache sur nos apis.
- Factoriser le code pour réduire sa complexité donc moins lourd en performances.
- Mise en place de linter plus strict et orienté sur les pratiques green.

## Etat du projet
Le projet est : _Terminé_ ✅

## Contact
Créer par [@AxekPhanor](https://github.com/AxekPhanor)

Mail : axel.phanor64@gmail.com

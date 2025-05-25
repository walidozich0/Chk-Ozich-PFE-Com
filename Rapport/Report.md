```
République Algérienne Démocratique et Populaire
Ministère de l’Enseignement Supérieur et de la Recherche Scientifique
Université des Sciences et de la Technologie Houari Boumediene (USTHB)
```

#### Faculté d’Informatique

## Mémoire de Licence

#### Domaine : Mathématiques et Informatique

#### Filière : Informatique

#### Spécialité : Ingénierie des Systèmes d’Information et des Logiciels

# Système de Gestion des Donations de Sang

# basé sur une Architecture Distribuée

_Réalisé par :_

M. CHERCHALI Mohamed Walid
M. GUERACHA Ramzi Wassim
M. BOUMAZA Imad Ediine
M. CHADOULI Mohamed Tahar
M. DZIRI Mohamed Idir

```
Encadré par :
M. CHERCHALI Karim
(SMART PARTNER)
```

```
Membres de jurées :
Président :M. ZERAOULIA Khaled
Membre : M. ZAIDI Abdelhalim
```

#### Année universitaire : 2024 – 2025

## Table des matières

- I Introduction
  - I.1 Introduction.
  - I.2 Problématique
  - I.3 Solution adoptée
  - I.4 Objectifs du projet
- II Etat de l’art
  - II.1 Analyse de marché et constats sur le terrain
    - II.1.1 Critères d’admissibilité des donneurs
  - II.2 Constats et anomalies relevés
  - II.3 Solutions actuelles et leurs lacunes
    - II.3.1 Marché algérien (Enjeux et opportunités) :.
- IIIPrésentation de la Solution
  - III.1 Présentation d’ensemble de la solution
  - III.2 Notre systeme design
  - III.3 Application CTS
  - III.4 Portail public et application mobile
  - III.5 Plateforme centrale de supervision (Dashboard)

# Table des figures

```
III.1 Schéma de conception du système....................... 6
III.2 Diagramme séquence d’une création d’une demande de sang........ 7
```

##### II

# Liste des tableaux

```
II.1 Types de dons et durée de conservation.................... 3
II.2 Solutions locales et limites........................... 5
```

##### III

# Chapitre I

# Introduction

### I.1 Introduction.

La gestion du don de sang est une problématique critique, à la fois pour la santé
publique et pour la réactivité des Centres de transfusion sanguine (CTS). Dès lors que
cette activité a fait l’objet de tentatives d’organisation, la plupart des défis organisation-
nels, techniques et communicationnels subsistent. Il s’agit d’un projet qui se situe dans
une démarche de modernisation de la chaîne du don de sang via la mise en œuvre d’un
système d’information distribué et à vocation de compenser les principales lacunes du
fonctionnement présent.

### I.2 Problématique

```
Les recherches en contexte ont éclairé trois grands champs de dysfonctionnements :
```

1. **Problèmes internes aux CTS** : Les centres de transfusion sanguine (CTS) ne
   disposent pas de système interne de gestion. Le non-suivi du stock et de la péremp-
   tion des poches de sang, conjugué à la non-traçabilité de la gestion des demandes
   entre les services, provoque un fort chevauchement de pertes d’eﬀicacité. De plus,
   les donneurs occasionnels ne sont pas identifiés ni fidélisés, ce qui réduit la réactivité
   en cas de besoin urgent.
2. **Dysfonctionnements du processus de collecte initiée par les patients :** le
   processus, le plus souvent déclenché directement par les patients ou leurs familles,
   est long, ineﬀicace et peu être automatisé. La culture du don volontaire est toujours
   marginale, et les urgences sont dépourvues de visibilité. L’absence de communication
   entre les différents acteurs (CTS, patients, donneurs) pérennise ces dysfonctionne-
   ments et diffuse les prises en charge.
3. **Manque de visibilité globale à l’échelle nationale :** Au niveau institution-
   nel, les autorités sanitaires ne disposent pas d’une vision consolidée de l’état des
   stocks régionaux. Les données sont fragmentées et dispersées, compliquant toute
   anticipation ou redistribution stratégique selon les besoins géographiques.

**Introduction**

### I.3 Solution adoptée

Pour répondre à ces enjeux, nous avons conçu une **solution logicielle distribuée**
reposant sur trois applications interdépendantes :

- **Application CTS** (déployée par centre) : front-end web + backend REST API,
  pour la gestion des stocks, des demandes et des donneurs, personnel et services
  d’hôpital.
- **Portail Public** : site web et mobile ouvert au grand public, permettant une com-
  munication rapide entre les donneurs et les CTSs (notifications, rappels, urgences,
  etc...) , visualiser les besoins en dons, de répondre aux demandes ou de s’inscrire
  comme donneur volontaire.
- **Plateforme de Centralisation** : interface de supervision nationale dédiée aux
  autorités sanitaires, pour centraliser les données de tous les CTS en temps réel.

Ces différentes composantes sont interconnectées par Message Broker, en permettant la
synchronisation des informations tout en respectant la logique de déploiement décentralisé.

### I.4 Objectifs du projet

```
Les objectifs principaux de ce projet sont :
```

- **Répondre aux interrogatives évoquées** : automatisation de la monitorisation
  des stocks, fluidification des échanges, mise en place d’une base centrale des don-
  neurs, renforcement de la visibilité des besoins d’urgence, etc.
- **Développer une architecture distribuée** en qualité de preuve de concept, dé-
  montrant la scalabilité et l’interopérabilité des systèmes modernes.
- **Obtenir et appliquer des compétences haut de gamme** en conception logi-
  cielle, telles que l’architecture distribuée, l’utilisation des patterns modernes (CQRS,
  DDD, Event-Driven, etc.) et les techniques de développement backend, frontend et
  mobile.

Ce rapport essaie de décrire d’abord les solutions et l’état de l’art déjà disponibles
dans le domaine, et ensuite de décrire en détail la solution développée et les résultats de
sa mise en place.

# Chapitre II

# Etat de l’art

### II.1 Analyse de marché et constats sur le terrain

Dans le cadre du présent projet, il a été menée une enquête dans plusieurs hôpitaux et
centres de transfusion avec pour objectif d’étudier les pratiques actuelles, les contraintes
à identifier et d’en déduire les règles métiers à mettre en œuvre.

#### II.1.1 Critères d’admissibilité des donneurs

- **Âge :** Au moins 18 ans (préférence à partir de 19 ans), jusqu’à 65 ans pour les
  hommes, 55 ans pour les femmes.
- **Poids :** en proportion de la taille (par exemple : 1,90 m → au moins 75 kg, 1,60 m
  → environ 50 kg).
- **État de santé :** tension artérielle normale, pas d’anémie, pas de maladies cardio-
  vasculaires. Restrictions spécifiques : Les fumeurs sont admis, mais la chicha est
  interdite (car elle augmente le taux d’hémoglobine).
- **Capacité et gestion des stocks :**
  **- Capacité maximale d’un centre :** 2 000 à 3 000 poches.
  **- Collecte quotidienne maximale :** 150 poches par jour maximum.
  **- Stock minimum recommandé :** 500 poches.
  **- Types de dons et durée de conservation :**

```
Type de don Durée de conservation
Sang total 45 jours
Plaquettes 5 jours
Plasma 45 jours
```

```
Tab.II.1 : Types de dons et durée de conservation
```

**Etat de l’art**

- **Donneurs réguliers :** Un donneur régulier est une personne qui donne 2 à 3 fois
  dans l’année. En cas d’urgence médicale, ces donneurs sont prioritaires.
- **Fréquence minimale entre deux dons :**
  **- Don total de sang :** au moins 3 mois entre chaque don.
  **- Don de plaquettes :** au moins 2 mois avant un nouveau don (de plaquettes
  ou de sang).
- **Croisement de sang entre hôpitaux :** Il existe un système d’échange interhos-
  pitalier, mais il est soumis aux conditions suivantes : Exigence d’un dossier médical
  justifiant l’urgence. Présence physique d’un représentant hospitalier receveur.
- Possibilité d’échangisme du sang non compatible contre du sang compatible, le cas
  échéant, si le stock le permet.
- **Processus de don de sang :**
  **-** Le donneur est amené à remplir un formulaire d’admission.
  **-** Un examen médical est effectué pour valider l’aptitude.
  **-** Le prélèvement est réalisé, si le donneur est considéré comme apte.
  **-** Le sang recueilli est ensuite analysé (groupage, contrôle qualité, etc.).

### II.2 Constats et anomalies relevés

**Les constats venant du terrain confirment les problématiques présentées
dans l’introduction :**

- Les constats venant du terrain confirment les problématiques présentées dans l’in-
  troduction :
- Absence de système intégré de suivi.
- Manque de traçabilité dans le traitement des demandes.
- Absence de réglementation des donneurs réguliers.
- Interaction insuﬀisante entre patients, CTS et donneurs.
- Absence de compilation nationale de la visibilité des besoins et des stocks

**Etat de l’art**

### II.3 Solutions actuelles et leurs lacunes

#### II.3.1 Marché algérien (Enjeux et opportunités) :.

1. **Données clés :**
   - **Couverture des besoins :**
     **-** 178 000 dons recensés en 2008 (￿4,1 dons/1000 habitants) vs objectif OMS
     de 10/1 000 (OMS, 2008).
     **-** Taux de couverture actuel estimé à 41% (Ministère de la Santé, 2023).
   - **Urgences routières :**
     **-** 8 996 décès liés aux accidents en 2020 (16 % des besoins urgents en sang)
     (ONS Algérie,2021).
2. **Solutions locales et limites :**

```
Type Exemples Limites
Outils rudimen-
taires
```

```
Excel, Access Pas d’interopérabilité ni de mise à jour
temps réel
Projets pilotes DonoSang (exemple
illustratif)
```

```
Géolocalisation imprécise, notifications
manuelles, adoption limitée
Sensibilisation Campagnes Face-
book/WhatsApp
```

```
Pas d’intégration avec les systèmes hos-
pitaliers
```

```
Tab.II.2 : Solutions locales et limites
```

3. **Opportunités technologiques**
   - **Pénétration mobile :** 85 % des Algériens possèdent un smartphone (ARPT,2024).
   - **Connectivité :** 72,9 % de la population algérienne est connectée à inter-
     net(Trade.gov, 2024).

```
Deux plateformes ont été identifiées comme étant utilisées :
```

- Ahyaaha (https ://ahyaaha.com/client/) : met en relation donneurs et receveurs,
  mais ne gère pas le cycle du don ni la communication avec les hôpitaux.
- SangDZ (https ://www.sangdz.com/fr) fait de même avec les mêmes limites (pas
  de suivi, pas d’alertes, pas de coordination institutionnelle).

# Chapitre III

# Présentation de la Solution

### III.1 Présentation d’ensemble de la solution

La solution proposée est une architecture logicielle distribuée pour se mettre à jour dans
la gestion du don de sang en Algérie. Elle repose sur trois plateformes complémentaires :

- Une application spécifique pour les Centres de Transfusion Sanguine (CTS).
- Un portail public accessible en ligne et une application mobile.
- Une plateforme centrale de surveillance et de statistiques.

Ces plateformes échangent des données entre elles avec le Message Broker Kafka afin de
permettre une synchronisation sécurisée et une visibilité transversale au niveau national.

### III.2 Notre systeme design

```
Fig.III.1 : Schéma de conception du système.
```

**Présentation de la Solution**

### III.3 Application CTS

**L’application CTS constitue le cœur opérationnel du système. Chaque centre
dispose d’un espace numérique personnel et sécurisé pour contrôler ses opé-
rations.**

1. **Gestion des donateurs**
   Le CTS permet de :
   - Enregistrer les donateurs occasionnels et réguliers.
   - Vérifier l’historique des dons par donateur.
   - mettre à jour les données des donateurs
2. **Gestion du stock de sang**
   Les fonctions sont :
   - Suivi en temps réel du stock de chaque type de produit sanguin (sang total,
     plasma, plaquettes).
   - Alertes de péremption et seuils critiques.
   - Historique des entrées et sorties du stock.
3. **Lancement des demandes de sang**
   Lorsqu’un patient nécessite un produit sanguin, le CTS peut :
   - Créer une demande de don et l’envoyer au portail public.
   - Définir les critères (groupe sanguin, quantité, etc.).
   - Suivre l’évolution de la demande (promesses de dons, clôture,etc.).

```
Fig.III.2 : Diagramme séquence d’une création d’une demande de sang
```

**Présentation de la Solution**

### III.4 Portail public et application mobile

**Le portail public est chargé de mobiliser les citoyens et de faciliter l’accès
à l’information.**

1. **Inscription des donneurs :**
   - Les utilisateurs peuvent s’inscrire, envoyer leurs données médicales, consulter
     leur historique de dons et ajuster leurs disponibilités.
2. **Réception et engagement aux appels de sang**
   Les appels produits par les CTS sont publiés automatiquement sur le portail. Les
   donneurs peuvent :
   - Voir les besoins en cours.
   - Se porter volontaire pour alimenter une demande spécifique.
   - Activer des notifications en fonction des CTS qui l’intéressent.
3. **Recherche géolocalisée**
   Le portail permet la possibilité de :
   - Lister les hôpitaux, les CTS et les donneurs par wilaya
   - Utiliser des filtres avancés (type de don, statut, compatibilité)
   - Offrir des services similaires aux plateformes actuelles (Ahyaaha, SangDZ) mais
     avec davantage de fiabilité, de suivi et d’intégration institutionnelle.

### III.5 Plateforme centrale de supervision (Dashboard)

**Cette plateforme est réservée aux autorités de santé, et dispose d’un rôle
stratégique.**

1. **Supervision nationale**
   Elle centralise les données de tous les CTS et donne accès à :
   - Une vue consolidée des stocks régionaux
   - Des informations détaillées sur les dons
2. **Sécurité des données**
   Cette interface est privée, contrairement au portail public. Cela assure un niveau
   de sécurité élevé des données médicales et s’efforce d’assurer qu’aucune institution
   non autorisée n’y ait accès.

# Technologies et architectures utilisées

**a. Backend –** [**ASP.NET**](http://ASP.NET) **Core & FastEndpoints**

[ASP.NET](http://ASP.NET) Core est un framework open source moderne développé par Microsoft pour construire des applications web, tout type d’APIs (REST, gRPC, websockets, etc.). Il est performant, multiplateforme et maintenu activement. Dans ce projet, le choix s’est porté sur FastEndpoints, une surcouche légère et plus expressive permettant de structurer les endpoints de manière explicite, tout en intégrant naturellement des concepts comme la validation, la documentation et les middleware et le binding des données des requêtes (path params, query params, body headers…) dans une seule instance de la classe de la requête que le développeur définit selon l’endpoint, et elle permet au développeur de définir des classes qui structurent la réponse retournée au client, même si la gestion des événements internes (background tasks, cron jobs) se fait avec l’approche pub/sub.

**b. ORM - Entity Framework Core**

EF Core est un ORM (Object-Relational Mapper) de Microsoft qui permet de travailler avec des bases de données en utilisant des objets C#. Il supporte le LINQ, la migration de schéma, le traçage des changements, et une personnalisation fine des entités via Fluent API. Il est utilisé ici pour mapper les entités métiers aux tables PostgreSQL sans manuellement écrire les scripts SQL, ce qui offre une meilleure expérience de développement.

**c. Base de données – PostgreSQL**

PostgreSQL est un système de gestion de base de données relationnelle très fiable, performant, open source et extensible. Il est utilisé dans ce projet pour sa robustesse, sa gestion stricte des types, sa compatibilité avec les outils modernes et ses fonctionnalités comme les index complexes, les vues matérialisées et la gestion des transactions avancées, et la possibilité de stocker des données relationnelles et des données JSON qui offre une flexibilité nécessaire dans les projets large scale.

**d. Frontend – Next.js, TypeScript, Flutter**

Next.js est un framework basé sur ReactJS, utilisé dans les projets front-end modernes car il offre un ensemble de fonctionnalités intégrées pour optimiser le **SEO**. Son mélange intelligent entre **CSR** (Client Side Rendering) pour l’interactivité, **SSR** (Server Side Rendering) pour le rendu dynamique et **SSG** (Static Site Generation) pour les performances en fait une solution très efficace. Il prend en charge **TypeScript** nativement, permettant un développement plus sûr et structuré grâce au typage statique. De plus, l’intégration avec **Tailwind CSS** facilite la création d’interfaces modernes, responsives et maintenables, directement via des classes utilitaires. Ensemble, Next.js, TypeScript et Tailwind offrent un écosystème puissant, cohérent et productif.

Flutter est un framework développé par Google pour créer des applications mobiles cross-platform. Il permet de partager le même code source pour Android et iOS, tout en conservant des performances natives.

**e. Sécurité – JWT**

Les JWT (JSON Web Tokens) sont utilisés pour gérer l’authentification et l’autorisation. Chaque utilisateur reçoit un token signé qui est utilisé dans les requêtes HTTP pour prouver son identité. Ce mécanisme permet une authentification sans sauvegarde d'état (stateless), compatible avec des architectures distribuées.

**f. Architecture – Clean Architecture DDDfollowing event-driven architecture principles**

**La Clean Architecturesépare clairement les responsabilités en différentes couches, où lesinteractions se font à travers le principe de l'injection de dépendances(Dependency Injection - DI) :**

- **Core : contient la logique métier pure (entités, interfaces, événements de domaine) ;**

- **UseCases / Application : gère la logique d’application, orchestrée notamment via MediatR (commandes, requêtes, règles métier) ;**

- **Infrastructure : implémente les services externes (base de données, SMTP, Kafka, etc.) ;**

- **Web / API : expose les endpoints, gère l’authentification, la validation et les communications entrantes.**

**Cette architecturefavorise un code testable, modulaire et hautement maintenable sur le longterme.**

**2\. Design Patterns etconcepts appliqués**

**a. CQRS (Command QueryResponsibility Segregation)**

**Le pattern CQRSconsiste à séparer les opérations de lecture (Query) des opérations d’écriture(Command). Chaque type de traitement a ses propres objets, handlers etpipelines. Cela permet d’optimiser les performances, la lisibilité du code etde mieux respecter le principe de responsabilité unique.**

**b. DDD (Domain-Driven Design)**

**Le DDD vise à alignerle modèle logiciel avec la logique métier réelle. Le cœur de l’applicationrepose sur des entités, des agrégats, des objets de valeur et des services dedomaine. Cela permet de construire un modèle riche, cohérent et centré sur les règlesmétier, avec une gouvernance claire des données et des comportements.**

**c. Event-Driven Architecture (EDA)**

**L’EDA repose sur lapublication et la consommation d’événements métier. Lorsqu’une action seproduit (ex : un don est validé), un événement est publié sur un bus (Kafka),et d’autres services peuvent réagir. Cela rend les services découplés, réactifset extensibles sans modifier les composants existants.**

**d. Repository Pattern**

**Le Repository Patternfournit une abstraction entre le domaine et la couche de persistance. Il permetde centraliser l’accès aux données et de tester le domaine sans dépendre de labase de données réelle.**

**e. Result Pattern**

**Ce pattern, utiliséici via la bibliothèque Ardalis.Result, standardise les retours des appelsmétiers. Chaque réponse contient un statut (Succès, Erreur, Invalide) avec unmessage clair et des détails.**

**f. Mediator Pattern**

**Le Mediator Patternest implémenté via la bibliothèque MediatR. Il permet de centraliser les appelsentre objets via des requêtes ou des commandes, sans couplage direct entre lesclasses. Cela réduit les dépendances et améliore la lisibilité.**

**2\. Docker –Conteneurisation et déploiement**

**Docker est uneplateforme de conteneurisation permettant de packager une application et sesdépendances dans un environnement isolé et reproductible, appelé 'conteneur'.Il permet un déploiement rapide, portable et cohérent sur différentsenvironnements (dev, test, production).**

**a. Image Docker**

**Une image est unmodèle immuable contenant tout ce qu’il faut pour exécuter une application :code, librairies, runtime, configurations. Elle est définie par un fichierDockerfile.**

**b. Conteneur**

**Un conteneur est uneinstance en exécution d’une image Docker. Chaque service (API, base de données,Kafka, etc.) peut être lancé dans son propre conteneur, isolé des autres.**

**c. Docker Compose**

**Docker Compose permetde définir et d’exécuter des applications multi-conteneurs via un fichier YAML.Il facilite l’orchestration locale des services nécessaires au projet.**

**3\. Aspire -Observabilité et orchestration .NET**

**Aspire est uneplateforme .NET moderne conçue pour faciliter la création, l’observabilité, laconfiguration et l’orchestration de services distribués. Elle s’intègreparfaitement avec Docker, Kubernetes et les standards du cloud natif.**

**a. Orchestration deservices**

**Aspire permet dedécrire les dépendances entre services (API, BDD, Kafka, Redis…) et de lesexécuter automatiquement ensemble. Il prend en charge le démarrage des servicesavec logs centralisés et visualisation des relations interservices.**

**b. Observabilité**

**Grâce à OpenTelemetry,Aspire offre la traçabilité des requêtes, le suivi des métriques deperformance, les logs structurés et les erreurs d’exécution. Cela permet undiagnostic rapide et une meilleure résilience.**

## Kafka –Architecture et fonctionnement

**Apache Kafka est uneplateforme distribuée de traitement de flux d’événements (event streaming)conçue pour la haute performance, la résilience et la scalabilité horizontale.Elle permet la publication, la souscription, le stockage et le traitement de donnéesen temps réel. Voici les principaux composants de son architecture :**

**a. Broker (MessageBroker)**

**Un broker Kafka est unserveur chargé de recevoir, stocker et distribuer les messages. Un clusterKafka est composé de plusieurs brokers, qui se coordonnent pour gérer lestopics et les partitions. La coordination entre les brokers s’effectue viaApache ZooKeeper (ou KRaft, la nouvelle alternative native à partir de Kafka3.x).**

**b. Topic**

**Un topic est unecatégorie logique de messages. Les producteurs publient leurs messages vers untopic, et les consommateurs s’y abonnent. Chaque topic est divisé enpartitions, ce qui permet le parallélisme, la résilience et une distributionéquilibrée de la charge.**_**Exemple**_ **: un topic BloodRequestCreated peut contenir tous les événementsde création de demandes de sang par les CTS.**

**c. Partition**

**Une partition est uneséquence ordonnée, immuable et persistante de messages. Chaque message dans unepartition a un offset unique. Les partitions permettent une lecture parallèlepar plusieurs consommateurs et facilitent la scalabilité.**

**d. Producer**

**Un producer est uneapplication ou un service qui publie des messages vers un ou plusieurs topics.Dans notre cas, le backend du CTS agit comme un producer lorsqu’il envoie unévénement (par exemple, la création d’une demande de sang).**

**e. Consumer**

**Un consumer lit lesmessages depuis un ou plusieurs topics. Il peut faire partie d’un groupe deconsommateurs (consumer group), où chaque partition est consommée par un seulmembre du groupe, permettant une répartition du traitement.**_**Exemple**_ **: le portail public et le dashboard central consomment lesévénements des CTS en temps réel pour mise à jour et affichage.**

**f. Cluster etscalabilité**

**Un cluster Kafka estun ensemble de brokers répartis sur plusieurs machines. Kafka garantit laréplication des partitions pour la haute disponibilité. Il est conçu pour gérerdes millions de messages par seconde, avec une latence faible, grâce à la distributionautomatique des partitions entre brokers.**

**g. Kafka Manager**

**Kafka Manager (ououtils similaires comme Confluent Control Center, AKHQ) est une interface degestion qui permet d’administrer visuellement les topics, les partitions, lesoffsets, les groupes de consommateurs et l’état du cluster. Cela simplifie lasurveillance et la maintenance des environnements Kafka en production.**

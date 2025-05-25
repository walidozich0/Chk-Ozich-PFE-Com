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

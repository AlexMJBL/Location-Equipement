# Location-Equipement
Application de location d’équipements avec API .NET Core et frontend Angular. Permet de consulter les équipements, réserver pour plusieurs jours, annuler une location et afficher l’état (disponible ou occupé) en temps réel avec notifications.

## ⚙️ Fonctionnalités

### API (ASP.NET Core)
- **GET** `/api/Equipement/Get` → Récupère la liste des équipements avec leur statut (disponible ou loué).
- **POST** `/api/Equipement/LouerEquipement/{id}` → Loue un équipement pour un certain nombre de jours.
- **PUT** `/api/Equipement/AnnulerLocation/{id}` → Annule une location en cours.

### Angular (Frontend)
- Affiche la liste des équipements.
- Réserver un équipement pour **1, 3, 5 ou 7 jours**.
- Annuler une réservation.
- Notifications (succès/erreur) via **ngx-toastr**.

---

## 🛠️ Technologies utilisées
- **Backend** : ASP.NET Core, Entity Framework Core, SQL Server  
- **Frontend** : Angular, TypeScript, ngx-toastr  
- **Base de données** : SQLite
---

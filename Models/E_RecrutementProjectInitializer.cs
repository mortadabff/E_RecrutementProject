using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace E_RecrutementProject.Models
{
    public class E_RecrutementProjectInitializer : DropCreateDatabaseAlways<E_RecrutementProjectContext>
        //DropCreateDatabaseIfModelChanges<E_RecrutementProjectContext>
    {
        protected override void Seed(E_RecrutementProjectContext context)
        {
            base.Seed(context);

            Recruteur recruteur1 = new Recruteur("NomRecruteur1", "Prenom1", "MotDePasse1", "Societe1", "Domaine1", 100, "111-111-1111", "mail1@example.com");
            Recruteur recruteur2 = new Recruteur("NomRecruteur2", "Prenom2", "MotDePasse2", "Societe2", "Domaine2", 200, "222-222-2222", "mail2@example.com");
            Recruteur recruteur3 = new Recruteur("NomRecruteur3", "Prenom3", "MotDePasse3", "Societe3", "Domaine3", 300, "333-333-3333", "mail3@example.com");
            Recruteur recruteur4 = new Recruteur("NomRecruteur4", "Prenom4", "MotDePasse4", "Societe4", "Domaine4", 400, "444-444-4444", "mail4@example.com");
            Recruteur recruteur5 = new Recruteur("NomRecruteur5", "Prenom5", "MotDePasse5", "Societe5", "Domaine5", 500, "555-555-5555", "mail5@example.com");

            // Instancier quelques objets Candidat
            Candidat candidat1 = new Candidat("NomCandidat1", "Prenom1", 25, "mail1@example.com", "MotDePasse1", "111-111-1111", "Diplome1");
            Candidat candidat2 = new Candidat("NomCandidat2", "Prenom2", 30, "mail2@example.com", "MotDePasse2", "222-222-2222", "Diplome2");
            Candidat candidat3 = new Candidat("NomCandidat3", "Prenom3", 28, "mail3@example.com", "MotDePasse3", "333-333-3333", "Diplome3");
            Candidat candidat4 = new Candidat("NomCandidat4", "Prenom4", 22, "mail4@example.com", "MotDePasse4", "444-444-4444", "Diplome4");
            Candidat candidat5 = new Candidat("NomCandidat5", "Prenom5", 27, "mail5@example.com", "MotDePasse5", "555-555-5555", "Diplome5");

            // Ajouter ces objets à votre base de données ou à une liste en mémoire, selon votre implémentation
            // Par exemple, si vous avez une liste statique de Recruteurs et de Candidats dans votre application :
            List<Recruteur> recruteurs = new List<Recruteur> { recruteur1, recruteur2, recruteur3, recruteur4, recruteur5 };
            List<Candidat> candidats = new List<Candidat> { candidat1, candidat2, candidat3, candidat4, candidat5 };

            // Ajouter ces objets à votre base de données ou à une liste en mémoire, selon votre implémentation
            // Par exemple, si vous avez une liste statique de Recruteurs et de Candidats dans votre application :
            recruteurs.ForEach(p => context.Recruteurs.Add(p));
            context.SaveChanges();
            candidats.ForEach(p => context.Candidats.Add(p));
            context.SaveChanges();

            var OffresListe = new List<Offre>
            {


            new Offre
            {
                         
                IdRecruteur=1,
                TypeContrat = TypeContrat.CDI,
                Secteur = "Informatique",
                Profil = "Ingénieur",
                Poste = "Développeur Senior",
                Remuneration = 80000
            },

             new Offre
            {
                IdRecruteur=2,
                TypeContrat = TypeContrat.CDD,
                Secteur = "Finance",
                Profil = "Master",
                Poste = "Analyste financier",
                Remuneration = 60000
            },

            new Offre
            {
                IdRecruteur=3,
                TypeContrat = TypeContrat.CDI,
                Secteur = "Santé",
                Profil = "Médecin",
                Poste = "Chirurgien",
                Remuneration = 120000
            },

            new Offre
            {
                IdRecruteur=4,
                TypeContrat = TypeContrat.CDD,
                Secteur = "Marketing",
                Profil = "Licence",
                Poste = "Assistant Marketing",
                Remuneration = 50000
            }

        };
            OffresListe.ForEach(p => context.Offres.Add(p));
            context.SaveChanges();

          
        }


    }
}
    

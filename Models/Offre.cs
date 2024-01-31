using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_RecrutementProject.Models
{
    public class Offre
    {
        [Key]

        private static int prochainId = 1;
       
        public int Id { get; private set; }
        public int IdRecruteur { get; set; }
        public TypeContrat TypeContrat { get; set; }
        public string Secteur { get; set; }
        public string Profil { get; set; }
        public string Poste { get; set; }
        public int Remuneration { get; set; }
        // Autres propriétés liées à une offre (ajoutez-les selon vos besoins)

        // Constructeur par défaut
        public Offre()
        {

           this.Id = prochainId++;
        }

        // Constructeur avec paramètres
        public Offre( int idRecruteur, TypeContrat typeContrat, string secteur, string profil, string poste, int remuneration)
        {
            this.Id = prochainId++;
            IdRecruteur = idRecruteur;
            TypeContrat = typeContrat;
            Secteur = secteur;
            Profil = profil;
            Poste = poste;
            Remuneration = remuneration;
        }

        


    }

    public enum TypeContrat
    {
        CDD,
        CDI
    }

}
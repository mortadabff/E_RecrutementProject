using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_RecrutementProject.Models
{
    public class Recruteur
    {
        [Key]
        public int Id_recruteur { get; set; } 
        public string Nom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Offre> Offres { get; set; }

        // Constructeur par défaut
        public Recruteur()
        {
            Offres = new HashSet<Offre>();
        }

        // Constructeur avec paramètres
        public Recruteur(int id_recruteur, string nom, string tel, string mail)
        {
            Id_recruteur = id_recruteur;
            Nom = nom;
            Tel = tel;
            Mail = mail;
            Offres = new HashSet<Offre>();
        }

        // Méthodes supplémentaires liées à une offre (ajoutez-les selon vos besoins)
    }
    
}
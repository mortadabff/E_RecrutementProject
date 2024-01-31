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

        public static int prochainId = 1;
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string NomSociete { get; set; }
        public string DomaineSociete { get; set; }
        public int EffectifSociete { get; set; }

        public string Tel { get; set; }
      


       // public List<Offre> Offres { get; set; }

        // Constructeur par défaut
        public Recruteur()
        {
            //Offres = Offres.ToList();
            this.Id = prochainId++;
        }

        


        // Constructeur avec paramètres
        public Recruteur( string nom, string prenom, string password , string nomSociete, string domaineSociete,int effectifSociete,string tel, string mail)
        {
           
            Nom = nom;
            Role = "Recruteur";
            Tel = tel;
            Mail = mail;
          //  Offres = Offres.ToList();
            this.Id = prochainId++;
            this.Prenom = prenom;
            this.Password = password;
            NomSociete = nomSociete;
            DomaineSociete = domaineSociete;
            EffectifSociete = effectifSociete;


        }

        // Méthodes supplémentaires liées à une offre (ajoutez-les selon vos besoins)
    }
    
}
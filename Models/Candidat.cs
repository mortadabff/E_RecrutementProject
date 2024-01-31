using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace E_RecrutementProject.Models
{
    public class Candidat 
    {
        [Key]

        public static int prochainId = 1;
        public int Id { get; private set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }

        public string Role { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string Diplome { get; set; }


        public Candidat()
        {
          this.Id = GetNextId();
        }

        // Constructeur avec paramètres
        public Candidat(string nom, string prenom, int age, string mail, string password,string tel, string diplome)
        {
            this.Id = GetNextId();
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Mail = mail;
            Password = password;
            Role = "Candidat";
            Tel = tel;
            Diplome = diplome;

        }


        
        private static int GetNextId()
        {
            return prochainId++;
        }


    }
}
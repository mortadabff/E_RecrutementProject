using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_RecrutementProject.Models
{
    public class Candidature
    {
        [Key]
        public static int prochainId = 1;
        public int Id { get; set; }
        public int IdCandidat { get; set; }
        public int IdOffre { get; set; }
        public int IdRecruteur { get; set; }
      //  public DateTime dateDeCandidature { get; set; }
        public string Nom {  get; set; }    
        public string Prenom {  get; set; } 
        public int Age { get; set; }
        public string Nationalite { get; set; }
        public string NiveauEtude { get; set; }
        public string Diplome { get; set; }
        public int AnneesExperience { get; set; }
        public string Motivation { get; set; }
        public Candidature()
        {
            this.Id = prochainId++;
        }

        // Constructeur avec paramètres
        public Candidature( int idCandidat, int idR,int idOf,string nom, string prenom , int age , string natioanlite , string niveauetude, string diplome, int anneExp, string motiv  )
        {
            this.Id = prochainId++;
            IdCandidat = idCandidat;
            IdRecruteur = idR;
            IdCandidat = idCandidat;
            IdOffre = idOf;
            Nom = nom;
            Prenom  = prenom;
            Motivation = motiv;
            AnneesExperience = anneExp;
            Nationalite = natioanlite;
            Diplome = diplome;
            NiveauEtude =niveauetude; 


        }


    }
}
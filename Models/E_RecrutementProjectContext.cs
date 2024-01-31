using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_RecrutementProject.Models
{
    public class E_RecrutementProjectContext : DbContext
    {
        public E_RecrutementProjectContext() : base("name=E_RecrutementProjectDB2") { }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Candidature> Candidatures { get; set; }
        public DbSet<Recruteur> Recruteurs { get; set; }
        public DbSet<Candidat> Candidats { get; set; }


    }
}
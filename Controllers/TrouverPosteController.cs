using E_RecrutementProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace E_RecrutementProject.Controllers
{
    public class TrouverPosteController : Controller
    {
        // GET: TrouverPoste
        private E_RecrutementProjectContext db = new E_RecrutementProjectContext();

        // GET: Offres
        public ActionResult Index()
        {
            return View(db.Offres.ToList());
        }

        public ActionResult CandidatureBienAjoute(int? id2)
        {

            if (id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id2);
            if (offre == null)
            {
                return HttpNotFound();
            }

            return View(offre);
        }
        public ActionResult Postuler(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }

            return View("Postuler",offre);
        }

        [HttpGet]
        public ActionResult SoummettrePostuler(int id, string nom,string prenom,int age , string nationalite,string niveauEtude,string diplome,int anneesExperience,string motivation)
        {
            using (E_RecrutementProjectContext db = new E_RecrutementProjectContext())
            {
                if (Session["userId"] != null)
                {
                    if (id == null)
                      {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                     }
                     Offre offre = db.Offres.Find(id);
                     if (offre == null)
                     {
                    return HttpNotFound();
                      }

                    int userId = Convert.ToInt32(Session["userId"]);


                    Candidature c = new Candidature(userId, offre.IdRecruteur, offre.Id, nom, prenom, age, nationalite, niveauEtude, diplome, anneesExperience, motivation);
                    db.Candidatures.Add(c);
                    db.SaveChanges();


                    return RedirectToAction("CandidatureBienAjoute", "TrouverPoste");
                }
                else {
                TempData["msg"] = "Quelques choses qui ne marche pas ";
                return RedirectToAction("LoginPage", "Authentification");

                }
            }




            //     return RedirectToAction("LoginPage", "Authentification");
        }

        public ActionResult ChercherOffres(string motCle)
        {
            List<Offre> offresTrouvees = new List<Offre>();

            if (motCle ==null || motCle == "")
            {
                // Si le mot-clé est nul ou vide, redirige vers l'index
                return RedirectToAction("Index");
            }
            else
            {
                using (E_RecrutementProjectContext db = new E_RecrutementProjectContext())
                {  // Recherche des offres qui contiennent le mot-clé dans l'un de leurs attributs
                    foreach (var offre in db.Offres)
                    {
                        if (offre.Poste.Contains(motCle.ToLower()) || offre.Profil.Contains(motCle.ToLower()) || offre.Secteur.Contains(motCle.ToLower())
                            || offre.Poste.Contains(motCle.ToUpper()) || offre.Profil.Contains(motCle.ToUpper()) || offre.Secteur.Contains(motCle.ToUpper()))
                        {
                            offresTrouvees.Add(offre); // Ajoutez l'offre à la liste des offres trouvées

                        }
                    }

                }
                  
            }

            // Retourne la liste des offres trouvées à la vue
             return View(offresTrouvees);
        }


        // GET: Offres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // GET: Offres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdRecruteur,TypeContrat,Secteur,Profil,Poste,Remuneration")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                db.Offres.Add(offre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offre);
        }

        // GET: Offres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdRecruteur,TypeContrat,Secteur,Profil,Poste,Remuneration")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offre);
        }

        // GET: Offres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offre offre = db.Offres.Find(id);
            db.Offres.Remove(offre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

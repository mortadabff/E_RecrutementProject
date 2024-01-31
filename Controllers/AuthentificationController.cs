using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using E_RecrutementProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;
using System.IO;
using System.Web.UI;
using Microsoft.Ajax.Utilities;

namespace E_RecrutementProject.Controllers
{
    public class AuthentificationController : Controller
    {

        public ActionResult LoginPage()
        {

            return View();

        }
        public ActionResult RegisterPage()
        {


            return View();

        }
        public ActionResult LogoutPage()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public ActionResult Login(string email, string password)
        {
            
           using (E_RecrutementProjectContext db = new E_RecrutementProjectContext())
            {
                foreach (var x in db.Recruteurs )
                {
                    if(x.Mail == email && x.Password == password)
                    {

                        Session["userName"] = x.Nom;
                        Session["userId"] = x.Id;
                        return RedirectToAction("Index", "Home");
                    }
                }
                foreach (var x in db.Candidats)
                {
                    if (x.Mail == email && x.Password == password)
                    {
                        Session["userName"] = x.Nom;
                        Session["userId"] = x.Id;
                        return RedirectToAction("Index", "Home");
                    }
                   
                }

               
            }
            TempData["msg"] = "Error de connexion , email ou mot de passe non valide";

            return RedirectToAction("LoginPage", "Authentification");
        }



        [HttpGet]
        public ActionResult RegisterRecruteur(string nom, string prenom, string email, string password1,  string password2,string tel, string nomSociete,string domaineSociete, int effectifSociete )
        {

            using (E_RecrutementProjectContext db = new E_RecrutementProjectContext())
            {
                bool isRecruteursTableEmpty = !db.Recruteurs.Any();        
            if (!isRecruteursTableEmpty)
                {

                    var result1 = db.Recruteurs.Where(x => x.Mail == email);
                    if(result1.Count() == 0 && password1 == password2)
                    {
                        Recruteur c = new Recruteur(nom, prenom, password1,nomSociete, domaineSociete, effectifSociete, tel, email) ;
                        db.Recruteurs.Add(c);
                        db.SaveChanges();
                        Session["userId"] = c.Id;
                        Session["userName"] = c.Nom;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        TempData["msg"] = "Le mail est déja utilisé ou les mots de passe ne sont pas les memes!!!";
                    }


                }
                else
                {
                    Recruteur c = new Recruteur(nom, prenom, password1, nomSociete, domaineSociete, effectifSociete, tel, email);
                    db.Recruteurs.Add(c);
                    db.SaveChanges();
                    Session["userName"] = c.Nom;
                    Session["userId"] = c.Id;
                    return RedirectToAction("Index", "Home");
                }
       
            }

            return RedirectToAction ("RegisterPage", "Authentification");

        }



        [HttpGet]
        public ActionResult RegisterCandidat(string nom, string prenom,string email, string password1, string password2, string tel, string diplome, int age)
        {

            using (E_RecrutementProjectContext db = new E_RecrutementProjectContext())
            {
                var result1 = db.Candidats.Where(x => x.Mail == email);
                if (result1.Count() == 0 && password1 == password2)
                {
                    
                    Candidat c = new Candidat(nom, prenom, age,email, password1, tel,diplome);
                    db.Candidats.Add(c);
                    db.SaveChanges() ;

                    Session["userName"] = c.Nom;
                    TempData["Session"] = c.Id;
                    return RedirectToAction("Index","Home");
                }
                else
                {

                    TempData["msg"] = "Le mail est déja utilisé ou les mots de passe ne sont pas les memes!!!";
                }
            }

            return RedirectToAction("RegisterPage", "Authentification");

        }



    }
}
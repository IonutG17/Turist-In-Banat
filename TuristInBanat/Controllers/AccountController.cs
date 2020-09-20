using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TuristInBanat.Models;
using TuristInBanat.ViewModels;

namespace TuristInBanat.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private ApplicationDBContext db = new ApplicationDBContext();

        //GET: Account/RegisterTurist (new)
        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegisterTurist()
        {
            return View();
        }

        // POST: /Account/RegisterTurist (new)
        [HttpPost]
        [AllowAnonymous]

        public ActionResult RegisterTurist(RegisterVM obj)
        {

            bool UserExists = db.Users.Any(x => x.Username == obj.Username);
            if (UserExists) //if the username is already in the database and exists
            {
                ViewBag.UsernameMessage = " Acest 'Nume utilizator' exista deja, va rugam alegeti altul.";
                return View();
            }

            bool EmailExists = db.Users.Any(x => x.Email == obj.Email);
            if (EmailExists) // if the email is already in the database and it exists
            {
                ViewBag.EmailMessage = " Acest Email exista deja in folosinta, va rugam alegeti alta adresa de email.";
                return View();
            }

            // if Username and Email are unique we register the user and save it in the database
            User u = new User();
            u.Username = obj.Username;
            u.Password = obj.Password;
            u.Email = obj.Email;
            u.ImageUrl = " ";
            u.CreatedOn = DateTime.Now;

            db.Users.Add(u);
            db.SaveChanges();

            return RedirectToAction("LoginTurist", "Account");
        }


        //GET: Account/LoginTurist (new)
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LoginTurist()
        {
            return View();
        }




        //POST: Account/LoginTurist (new)
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginTurist(LoginVM obj)
        {
            bool userExists = db.Users.Any(u => u.Username == obj.Username && u.Password == obj.Password);

            if (userExists)
            {
                Session["UseId"] = db.Users.Single(x => x.Username == obj.Username).Id;
                Session["ImageUrl"] = db.Users.Single(x => x.Username == obj.Username).ImageUrl;

                return RedirectToAction("Index", "CommentSection");
            }
            // in case of incorect email or password
            ViewBag.LoginMessage = "Nume utilizator sau parola incorecte!";

            return View();
        }


        //GET: Account/LogoutTurist (new)
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogoutTurist()
        {
            Session["UseId"] = 0;
            return RedirectToAction("Index", "Home");
        }
    }
}
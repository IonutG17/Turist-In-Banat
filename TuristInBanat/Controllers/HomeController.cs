using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using TuristInBanat.Models;
using TuristInBanat.ViewModels;

namespace TuristInBanat.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        public ActionResult Index()
        {
            Session["UseId"] = 0;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Cine suntem noi.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Daca doriti sa luati legatura cu noi, ne puteti contacta prin una din metodele de mai jos.";

            return View();
        }


        public ActionResult Recommendations()
        {
            ViewBag.Message = "Recomandarile noastre pentru urmatoarele tale destinatii";

            return View();
        }

        public ActionResult Spontaneous()
        {
            ViewBag.Message = "Fii spontan, daca esti in lipsa de idei foloseste generatorul nostru aleator de destinatii.";

            return View();
        }

        public ActionResult Experiences()
        {
            ViewBag.Message = "Experientele dumneavoastra sunt importante, impartasiti cu noi locurile minunate vizitate ce merita vazute si nu sunt (inca) in listele noastre.";

            var comments = db.Comments.Include(x => x.Replies)
                .OrderByDescending(x => x.CreatedOn).ToList();

            return View(comments);
        }




        //SideMenu Items


        public ActionResult Orase()
        {
            ViewBag.Message = "Ce spuneti de o lista cu cele mai reprezentative orase din aceasta regiune, pentru a va ajuta in alegerea dumneavostra?";

            return View();
        }

        public ActionResult Natura()
        {
            ViewBag.Message = "Aer curat, liniste si verdeata. Reteta perfecta pentru a va reincarca bateriile.";

            return View();
        }

        public ActionResult Atractii_sezoniere()
        {
            ViewBag.Message = "Indiferent de sezon, regiunea de vest a tarii ofera destinatii pentru toate gusturile, fie ca vorbim de relaxare pe timpul verii sau sporturi si atractii de iarna.";

            return View();
        }

        public ActionResult Circuite_trasee()
        {
            ViewBag.Message = "Locul perfect unde gasiti idei pentru drumetii sau excursii scurte de cateva zile.";

            return View();
        }

        public ActionResult Gradini_zoo()
        {
            ViewBag.Message = "Pentru cei mici dar si pentru cei mari, plimbarile in aer liber si printre animale pot fi chiar terapeutice. In zona de Vest avem cateva astfel de locuri foarte frumoase, chiar la standarde europene.";

            return View();
        }

        public ActionResult Sporturi_activitati()
        {
            ViewBag.Message = "Parcuri de aventura? Tiroliene si paintball? Gasim de toate pentru toti, distractie placuta!";

            return View();
        }

        public ActionResult Evenimente_culturale()
        {
            ViewBag.Message = "Fie ca e vorba de festivaluri, concerte sau spectacole, socializarea si intalnirile cu prietenii sunt foarte importante in zilele noastre.";

            return View();
        }

        public ActionResult Restaurante_traditionale()
        {
            ViewBag.Message = "Mancare traditionala romaneasca dar nu numai. Locuri unde cu siguranta veti spune ca e 'ca la mama acasa'.";

            return View();
        }

        public ActionResult Relaxare_spa()
        {
            ViewBag.Message = "Dupa o zi lunga de munca ne putem relaxa la o piscina, masaj sau si doar la o iesire intr-unul din faimoasele pub-uri din zona.";

            return View();
        }

        public ActionResult Shopping()
        {
            ViewBag.Message = "Magazinele si mall-urile sunt locurile perfecte in care putem face si gasi cate putin din orice. De la suveniruri la pauze scurte de masa si pana la cumparaturi dintre cele mai diverse pentru cei dragi.";

            return View();
        }

        public ActionResult Hoteluri_pensiuni()
        {
            ViewBag.Message = "Sigur ca drumetiile de o zi sunt foarte frumoase dar pot fi si obositoare. In aceasta sectiune puteti vedea unele din cele mai frumoase locatii pentru a petrece cateva nopti in vacantele dumneavoastra.";

            return View();
        }


    }
}
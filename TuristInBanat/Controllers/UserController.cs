using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using TuristInBanat.Models;
using TuristInBanat.ViewModels;
using System.IO;

namespace TuristInBanat.Controllers
{
    public class UserController : Controller
    {

        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: User
        public ActionResult UserProfile()
        {

            int userId = Convert.ToInt32(Session["UseId"]);

            if (userId == 0) // if user is not logged in
            {
                return RedirectToAction("LoginTurist", "Account");
            }

            return View(db.Users.Find(userId));
        }

        // Post: User/UpdatePicture
        public ActionResult UpdatePicture(PictureVM obj)
        {

            int userId = Convert.ToInt32(Session["UseId"]);

            if (userId == 0) // if user is not logged in
            {
                return RedirectToAction("LoginTurist", "Account");
            }

            var file = obj.Picture;

            User u = db.Users.Find(userId);
            if (file != null)
            {
                //Saving the image
                var extension = Path.GetExtension(file.FileName);
                string id_and_extension = userId + extension;
                string imgUrl = "~/ProfileImages/" + id_and_extension;
                u.ImageUrl = imgUrl;

                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();

                // If the folder to store the pictures doesen't exist -> create it.
                var path = Server.MapPath("~/ProfileImages/");
                if (!Directory.Exists(path))

                {
                    Directory.CreateDirectory(path);
                }

                //Updating ones picture, if they already have one and want to change it.
                if ((System.IO.File.Exists(path + id_and_extension)))
                {
                    System.IO.File.Delete(path + id_and_extension);
                }

                file.SaveAs((path + id_and_extension));
            }

            return RedirectToAction("UserProfile");
        }

    }
}
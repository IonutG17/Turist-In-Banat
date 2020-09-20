using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TuristInBanat.Models;
using TuristInBanat.ViewModels;

namespace TuristInBanat.Controllers
{
    public class CommentSectionController : Controller
    {
        // GET: CommentSection
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: ChatRoom
        public ActionResult Index()
        {

            ViewBag.Message = "Experientele dumneavoastra sunt importante, impartasiti cu noi locurile minunate vizitate ce merita vazute si nu sunt (inca) in listele noastre.";

            var comments = db.Comments.Include(x => x.Replies)
                .OrderByDescending(x => x.CreatedOn).ToList();

            return View(comments);
        }

        // POST: Experiences/PostReply
        [HttpPost]
        public ActionResult PostReply(ReplyVM obj)
        {
            int userId = Convert.ToInt32(Session["UseId"]);

            if (userId == 0)
            {
                return RedirectToAction("LoginTurist", "Account");
            }

            ViewBag.sessionId = userId;

            Reply r = new Reply();
            r.Text = obj.Reply;
            r.CommentId = obj.CID;
            r.UserId = userId;
            r.CreatedOn = DateTime.Now;

            db.Replies.Add(r);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        // POST: Experiences/PostComment
        [HttpPost]
        public ActionResult PostComment(string CommentText)
        {
            int userId = Convert.ToInt32(Session["UseId"]);

            if (userId == 0)
            {
                return RedirectToAction("LoginTurist", "Account");
            }

            Comment c = new Comment();
            c.Text = CommentText;
            c.CreatedOn = DateTime.Now;
            c.UserId = userId;

            db.Comments.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
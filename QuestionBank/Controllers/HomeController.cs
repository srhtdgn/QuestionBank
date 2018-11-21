using QuestionBank.Infrastructure;
using QuestionBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionBank.Controllers
{
    [SelectedTab("Home")]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<KullaniciDers> ders;
            QuestionBankDbContext db = new QuestionBankDbContext();
            ders = db.KullaniciDers.Where(x => x.Kullanici.KullaniciAdi.Equals(User.Identity.Name)).ToList();
            return View(ders);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using FunTranslation.Models;
using System.Web;
using System.Web.Mvc;

namespace FunTranslation.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTranslations()
        {
            FunnyTranslateEntities db = new FunnyTranslateEntities();
            return Json(db.Translations.ToList(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddTranslation(Translations translate)
        {
            FunnyTranslateEntities db = new FunnyTranslateEntities();
            try
            {
                var result = db.Translations.Max(x => x.TranslationID);
                int result2 = Convert.ToInt32(result);
                result2 = result2+1;
                translate.TranslationID = result2;
                translate.TranslationTime = DateTime.Now;
                db.Translations.Add(translate);
                db.SaveChanges();
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
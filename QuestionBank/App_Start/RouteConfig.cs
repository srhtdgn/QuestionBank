using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuestionBank
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(name: "Home", url: "", defaults: new { controller = "Home", action = "Index" });
            routes.MapRoute(name: "Login", url: "GirisYap", defaults: new { controller = "Account", action = "Login" });
            routes.MapRoute(name: "Logout", url: "CikisYap", defaults: new { controller = "Account", action = "Logout" });
            #region Account
            routes.MapRoute(name: "ProfileDetail", url: "Profil", defaults: new { controller = "Account", action = "ProfileDetail" });
            routes.MapRoute(name: "ChangeMail", url: "ChangeMail", defaults: new { controller = "Account", action = "ChangeMail" });
            routes.MapRoute(name: "ChangePhoto", url: "ChangePhoto", defaults: new { controller = "Account", action = "ChangePhoto" });
            routes.MapRoute(name: "ChangePassword", url: "ChangePassword", defaults: new { controller = "Account", action = "ChangePassword" });
            #endregion
            #region Lessons
            routes.MapRoute(name: "Lessons", url: "Dersler", defaults: new { controller = "Lesson", action = "Index" });
            routes.MapRoute(name: "AddLesson", url: "DersEkle", defaults: new { controller = "Lesson", action = "Add" });
            routes.MapRoute(name: "EditLesson", url: "DersDuzenle/{ID}", defaults: new { controller = "Lesson", action = "Edit" });
            routes.MapRoute(name: "DeleteLesson", url: "DersSil", defaults: new { controller = "Lesson", action = "Delete" });
            #endregion
      
            #region Users
            routes.MapRoute(name: "Users", url: "Kullanicilar", defaults: new { controller = "Users", action = "Index" });
            routes.MapRoute(name: "AddUser", url: "KullaniciEkle", defaults: new { controller = "Users", action = "Add" });
            routes.MapRoute(name: "EditUser", url: "KullaniciDuzenle/{ID}", defaults: new { controller = "Users", action = "Edit" });
            routes.MapRoute(name: "DeleteUser", url: "KullaniciSil", defaults: new { controller = "Users", action = "Delete" });
            #endregion

            #region Topic
            routes.MapRoute(name: "Topics", url: "Konular", defaults: new { controller = "Topic", action = "Index" });
            routes.MapRoute(name: "AddTopic", url: "KonuEkle", defaults: new { controller = "Topic", action = "Add" });
            routes.MapRoute(name: "EditTopic", url: "KonuDuzenle/{ID}", defaults: new { controller = "Topic", action = "Edit" });
            routes.MapRoute(name: "DeleteTopic", url: "KonuSil", defaults: new { controller = "Topic", action = "Delete" });
            routes.MapRoute(name: "TopicDersKonulari", url: "DersKonulari", defaults: new { controller = "Topic", action = "DersKonulari" });
            #endregion

            #region Question
            routes.MapRoute(name: "Questions", url: "Sorular", defaults: new { controller = "Question", action = "Index" });
            routes.MapRoute(name: "AddQuestion", url: "SoruEkle", defaults: new { controller = "Question", action = "Add" });
            //routes.MapRoute(name: "EditQuestion", url: "SoruDuzenle/{ID}", defaults: new { controller = "Question", action = "Edit" });
            routes.MapRoute(name: "DeleteQuestion", url: "SoruSil", defaults: new { controller = "Question", action = "Delete" });

            routes.MapRoute(name: "GetLessonsTopic", url: "DersinKonulari", defaults: new { controller = "Question", action = "GetLessonsTopic" });
            routes.MapRoute(name: "AddQuestionWithAjax", url: "SoruEkle2", defaults: new { controller = "Question", action = "AddQuestion" });

            #endregion


            routes.MapRoute(name: "ExamPrepare", url: "SinavHazirla", defaults: new { controller = "Exam", action = "Prepare" });
            routes.MapRoute(name: "ExamShow", url: "SinavGoster", defaults: new { controller = "Exam", action = "Show" });

        }
    }
}

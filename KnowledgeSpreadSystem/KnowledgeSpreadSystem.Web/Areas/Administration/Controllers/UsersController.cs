namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base;

    public class UsersController : AdministratorController
    {
        public UsersController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return this.PartialView();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToModerators(string User)
        {
            var courseId = HttpContext.Session["courseId"];
            var course = this.Data.Courses.Find(courseId);
            if (course == null)
            {
                this.AddNotification("No such course exists!", "error");
                return this.RedirectToAction("Index");
            }
            var userExists = this.Data.Users.Find(User);
            if (userExists == null || course.Moderators.Any(m => m.Id == User))
            {
                this.AddNotification("No such user exists or the user is not eligible for that operation!", "error");
                return this.RedirectToAction("Index");
            }
            course.Moderators.Add(userExists);
            if (userExists.Courses.All(c => c.Id != course.Id))
            {
                userExists.Courses.Add(course);
            }
            this.Data.SaveChanges();
            this.AddNotification(
                                 "Successfully added " + userExists.UserName + " to moderators for course " + course.Name,
                                 "success");
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromModerators(string Moderator)
        {
            var courseId = HttpContext.Session["courseId"];
            var course = this.Data.Courses.Find(courseId);
            if (course == null)
            {
                this.AddNotification("No such course exists!", "error");
                return this.RedirectToAction("Index");
            }
            var userExists = this.Data.Users.Find(Moderator);
            if (Moderator == null || course.Moderators.All(m => m.Id != Moderator))
            {
                this.AddNotification("No such user exists or the user is not eligible for that operation!", "error");
                return this.RedirectToAction("Index");
            }
            course.Moderators.Remove(userExists);
            if (userExists.Courses.Any(c => c.Id == course.Id))
            {
                userExists.Courses.Remove(course);
            }
            this.Data.SaveChanges();
            this.AddNotification(
                                 "Successfully removed " + userExists.UserName + " from moderators for course " + course.Name,
                                 "success");
            return RedirectToAction("Index");
        }

    }
}
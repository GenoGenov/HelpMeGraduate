namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;
    using KnowledgeSpreadSystem.Web.ViewModels.Insight;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

    public class InsightsController : BaseController
    {
        // GET: Insights
        public InsightsController(IKSSData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult CreateForModule(int id)
        {
            var module = this.Data.CourseModules.Find(id);
            if (module == null)
            {
                this.AddNotification("No such module exists!", "error");
                return this.RedirectToAction("Index", "Home");
            }

            if (!this.IsEligible(module.CourseId))
            {
                this.AddNotification("You are not enrolled for that module's course!", "error");
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel = Mapper.Map<SimpleViewModel>(module);
            return this.View("CreateInsight", new InsightViewModel { Target = viewModel });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForModule(int id, InsightViewModel model)
        {
            var courseModule = this.Data.CourseModules.Find(id);
            if (!this.IsEligible(courseModule.CourseId))
            {
                this.AddNotification("You are not enrolled for that course!", "error");
                return this.RedirectToAction("Index", "Home");
            }
            var insight = new Insight() { ModuleId = id, CourseId = courseModule.CourseId};

            var successResult = this.RedirectToAction("Index", "Enrolment", new { id = id });
            var viewResult = this.CreateInsight(successResult, insight, model);

            if (viewResult == successResult)
            {
                this.AddNotification("Successfully created insight for module " + model.Target.Name + " !", "success");
            }

            return viewResult;
        }

        [HttpGet]
        public ActionResult CreateForCourse(int id)
        {
            if (!this.IsEligible(id))
            {
                this.AddNotification("You are not enrolled for that course!", "error");
                return this.RedirectToAction("Index", "Home");
            }

            var module = this.Data.CourseModules.Find(id);
            if (module == null)
            {
                this.AddNotification("No such course exists!", "error");
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel = Mapper.Map<SimpleViewModel>(module);
            return this.View("CreateInsight", new InsightViewModel { Target = viewModel, });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForCourse(int id, InsightViewModel model)
        {
            if (!this.IsEligible(id))
            {
                this.AddNotification("You are not enrolled for that course!", "error");
                return this.RedirectToAction("Index", "Home");
            }
            var insight = new Insight() { CourseId = id };

            var successResult = this.RedirectToAction("Index", "Enrolment", new { id = model.Target.Id });
            var viewResult = this.CreateInsight(successResult, insight, model);

            if (viewResult == successResult)
            {
                this.AddNotification("Successfully created insight for course " + model.Target.Name + " !", "success");
            }

            return viewResult;
        }

        public ActionResult ReadForCourse([DataSourceRequest] DataSourceRequest request, int? id)
        {
            var data = this.Data.Insigths.All();
            data = id == null ? data : data.Where(x => x.CourseId == id && x.ModuleId == null);

            var insights = data.Project().To<InsightViewModel>();
            return this.Json(insights.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReadForModule([DataSourceRequest] DataSourceRequest request, int? id)
        {
            var data = this.Data.Insigths.All();
            data = id == null ? data : data.Where(x => x.ModuleId == id);

            var insights = data.Project().To<InsightViewModel>();
            return this.Json(insights.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        private ActionResult CreateInsight(ActionResult successResult, Insight initial, InsightViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View("CreateInsight", model);
            }

            initial.Content = model.Content;
            initial.AuthorId = this.CurrentUser.Id;
            this.Data.Insigths.Add(initial);
            this.Data.SaveChanges();

            return successResult;
        }

        private bool IsEligible(int courseId)
        {
            return this.User.IsInRole("Administrator") || this.CurrentUser.Courses.Any(x => x.Id == courseId);
        }
    }
}
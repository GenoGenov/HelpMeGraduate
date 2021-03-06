﻿namespace KnowledgeSpreadSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Web.Controllers.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Extensions;
    using KnowledgeSpreadSystem.Web.ViewModels;

    [Authorize]
    public class FacultiesController : BaseController
    {
        // GET: Faculties
        public FacultiesController(IKSSData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var faculty = this.Data.Faculties.Find(id);

            var mapped = Mapper.Map<FacultyViewModel>(faculty);

            ViewBag.Name = faculty.University.Name;
            ViewBag.Id = faculty.UniversityId;

            return View(mapped);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request, int? id)
        {
            var data = this.Data.Faculties.All();
            data = id == null ? data : data.Where(x => x.UniversityId == id);

            var faculties = data.Project().To<FacultyViewModel>()
                 .ForEach(x =>
                 {
                     x.Description = x.Description.ToShortString(250);
                     return x;
                 });
            return this.Json(faculties.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
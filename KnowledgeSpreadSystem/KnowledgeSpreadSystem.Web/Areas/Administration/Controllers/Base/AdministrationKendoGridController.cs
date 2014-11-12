namespace KnowledgeSpreadSystem.Web.Areas.Administration.Controllers.Base
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using AutoMapper;

    using KnowledgeSpreadSystem.Data;
    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Controllers;
    using KnowledgeSpreadSystem.Web.Controllers.Base;

    public abstract class AdministrationKendoGridController : BaseKendoGridController
    {
        public AdministrationKendoGridController(IKSSData data)
            : base(data)
        {
        }



        [NonAction]
        protected virtual T Create<T>(object model) where T : class 
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dbModel = Mapper.Map<T>(model);
                this.ChangeStateAndSave(dbModel, EntityState.Added);
                return dbModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : AuditInfo, IDeletableEntity where TViewModel : AdminViewModel
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dbModel = this.Data.GetDeletableGenericRepository<TModel>().Find(id);
                Mapper.Map(model, dbModel);
                this.ChangeStateAndSave(dbModel, EntityState.Modified);
                model.ModifiedOn = dbModel.ModifiedOn;
            }
        }

        protected virtual void Delete<TModel>(object id, bool deleteRecursive = false) where TModel : class, IDeletableEntity
        {
            var repository = this.Data.GetDeletableGenericRepository<TModel>();
            var dbModel = repository.Find(id);
            repository.Delete(dbModel);

            if (deleteRecursive)
            {
               

                var collections =
                    dbModel.GetType()
                           .GetProperties()
                           .Where(
                                  x =>
                                  x.PropertyType.IsGenericType
                                  && x.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
                                  && typeof(IDeletableEntity).IsAssignableFrom(x.PropertyType.GetGenericArguments()[0]));
                foreach (var propertyInfo in collections)
                {
                    var repositoryType = propertyInfo.PropertyType.GetGenericArguments()[0];
                    var thisMethod =
                        typeof(AdministrationKendoGridController).GetMethod(
                                                              "Delete",
                                                              BindingFlags.NonPublic | BindingFlags.Instance
                                                              | BindingFlags.DeclaredOnly)
                                                   .MakeGenericMethod(repositoryType);
                    var collection = (IEnumerable)propertyInfo.GetValue(dbModel);
                    foreach (var item in collection)
                    {
                        var a = item.GetType()
                                    .GetProperty(
                                                 "Id",
                                                 BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
                        thisMethod.Invoke(
                                          this,
                                          new object[]
                                              {
                                                  item.GetType()
                                                      .GetProperty(
                                                                   "Id",
                                                                   BindingFlags.GetProperty | BindingFlags.Public
                                                                   | BindingFlags.Instance)
                                                      .GetValue(item),
                                                  true
                                              });
                    }
                }
            }

            this.Data.SaveChanges();
        }


        private void ChangeStateAndSave(object dbModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dbModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}
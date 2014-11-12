namespace KnowledgeSpreadSystem.Web.ViewModels
{
    using System.Collections.Generic;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;
    using KnowledgeSpreadSystem.Web.ViewModels.Base;

    public class UniversityViewModel : BaseViewModel, IMapFrom<University>
    {
        public string About { get; set; }
    }
}
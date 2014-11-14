namespace KnowledgeSpreadSystem.Web.ViewModels
{
    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;
    using KnowledgeSpreadSystem.Web.ViewModels.Base;

    public class UniversityViewModel : BaseViewModel, IMapFrom<University>
    {
        public string About { get; set; }
    }
}
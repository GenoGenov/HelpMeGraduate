﻿namespace KnowledgeSpreadSystem.Web.ViewModels
{
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;
    using KnowledgeSpreadSystem.Web.ViewModels.Base;

    public class FacultyViewModel : BaseViewModel, IMapFrom<Faculty>
    {
        public string Description { get; set; }
    }
}
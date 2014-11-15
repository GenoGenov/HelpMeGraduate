namespace KnowledgeSpreadSystem.Web.ViewModels.Module
{
    using System;
    using System.Collections.Generic;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;
    using KnowledgeSpreadSystem.Web.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.ViewModels.Insight;
    using KnowledgeSpreadSystem.Web.ViewModels.Resource;

    public class ModuleViewModel : BaseViewModel, IMapFrom<CourseModule>, ISimpleView<SimpleViewModel>
    {
        public string Description { get; set; }

        public DateTime Started { get; set; }

        public DateTime End { get; set; }

        public string Lecturer { get; set; }

        public ICollection<InsightViewModel> Insights { get; set; }

        public ICollection<ResourceViewModel> Resources { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels
{
    using System.Web.Mvc;

    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class SimpleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
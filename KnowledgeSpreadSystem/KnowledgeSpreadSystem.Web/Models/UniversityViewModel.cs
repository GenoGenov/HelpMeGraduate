using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.Models
{
    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class UniversityViewModel:IMapFrom<University>
    {
        public string Name { get; set; }

        public string About { get; set; }
    }
}
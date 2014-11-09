using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.Areas.Administration.Models
{
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class EventViewModel:IMapFrom<CalendarEvent>
    {
    }
}
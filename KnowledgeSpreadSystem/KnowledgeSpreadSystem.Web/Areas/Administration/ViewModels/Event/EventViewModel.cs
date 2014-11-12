namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Event
{
    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class EventViewModel : AdminViewModel, IMapFrom<CalendarEvent>
    {
    }
}
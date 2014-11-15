namespace KnowledgeSpreadSystem.Models.Base.ResourcefulEntity
{
    using System.Collections.Generic;

    public interface IResourcefulEntity
    {
        ICollection<Resource> Resources { get; set; }

        ICollection<Insight> Insights { get; set; }

        ICollection<CalendarEvent> Events { get; set; }
    }
}

namespace KnowledgeSpreadSystem.Models.Base.ResourcefulEntity
{
    using System.Collections.Generic;

    using KnowledgeSpreadSystem.Data.Common.Models;

    public abstract class ResourcefulEntity : AuditInfo, IResourcefulEntity
    {
        private ICollection<Resource> resources;

        private ICollection<Insight> insigths;

        private ICollection<CalendarEvent> events;

        public ResourcefulEntity()
        {
            this.resources = new HashSet<Resource>();
            this.insigths = new HashSet<Insight>();
            this.events = new HashSet<CalendarEvent>();
        }

        public virtual ICollection<CalendarEvent> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
            }
        }

        public virtual ICollection<Resource> Resources
        {
            get
            {
                return this.resources;
            }
            set
            {
                this.resources = value;
            }
        }

        public virtual ICollection<Insight> Insights
        {
            get
            {
                return this.insigths;
            }
            set
            {
                this.insigths = value;
            }
        }
    }
}

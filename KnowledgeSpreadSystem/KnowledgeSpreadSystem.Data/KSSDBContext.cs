namespace KnowledgeSpreadSystem.Data
{
    using System.Data.Entity;

    using KnowledgeSpreadSystem.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class KSSDBContext : IdentityDbContext<User>
    {
        public KSSDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static KSSDBContext Create()
        {
            return new KSSDBContext();
        }

        public virtual IDbSet<CalendarEvent> CalendarEvents { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<CourseModule> CourseModules { get; set; }

        public virtual IDbSet<Facoulty> Facoulties { get; set; }

        public virtual IDbSet<Resource> Resources { get; set; }

        public virtual IDbSet<University> Universities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facoulty>().HasRequired(f => f.University).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ChatMessage>().HasRequired(m=>m.Receiver).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
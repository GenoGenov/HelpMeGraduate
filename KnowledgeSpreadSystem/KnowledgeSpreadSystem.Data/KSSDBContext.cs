namespace KnowledgeSpreadSystem.Data
{
    using System.Data.Entity;

    using KnowledgeSpreadSystem.Data.Migrations;
    using KnowledgeSpreadSystem.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class KSSDBContext : IdentityDbContext<User>
    {
        public KSSDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KSSDBContext, Configuration>());
        }

        public virtual IDbSet<CalendarEvent> CalendarEvents { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<CourseModule> CourseModules { get; set; }

        public virtual IDbSet<Faculty> Faculties { get; set; }

        public virtual IDbSet<Resource> Resources { get; set; }

        public virtual IDbSet<University> Universities { get; set; }

        public static KSSDBContext Create()
        {
            return new KSSDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>().HasRequired(f => f.University).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<CourseModule>().HasRequired(f => f.Course).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ChatMessage>().HasRequired(m => m.Receiver).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<CourseModule>().HasRequired(m => m.Moderator).WithOptional().WillCascadeOnDelete(false);
            modelBuilder.Entity<Course>().HasRequired(m => m.Moderator).WithOptional().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
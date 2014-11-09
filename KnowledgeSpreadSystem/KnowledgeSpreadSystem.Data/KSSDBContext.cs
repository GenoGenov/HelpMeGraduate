namespace KnowledgeSpreadSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using KnowledgeSpreadSystem.Data.Common.Models;
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

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                        .HasRequired(f => f.University)
                        .WithMany(n => n.Faculties).WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseModule>()
                        .HasRequired(f => f.Course)
                        .WithMany(n => n.CourseModules)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChatMessage>().HasRequired(m => m.Receiver).WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
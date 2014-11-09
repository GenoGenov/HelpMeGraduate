namespace KnowledgeSpreadSystem.Data
{
    using System.Data.Entity;

    using KnowledgeSpreadSystem.Data.Common.Repositories;
    using KnowledgeSpreadSystem.Models;

    public interface IKSSData
    {
        DbContext Context { get; }

        IDeletableEntityRepository<User> Users { get; }

        IDeletableEntityRepository<CalendarEvent> CalendarEvents { get; }
        
        IDeletableEntityRepository<ChatMessage> ChatMessages { get; }
        
        IDeletableEntityRepository<Course> Courses { get; }

        IDeletableEntityRepository<CourseModule> CourseModules { get; }

        IDeletableEntityRepository<Faculty> Faculties { get; }

        IDeletableEntityRepository<Resource> Recourses { get; }
 
        IDeletableEntityRepository<University> Universities { get; }

        int SaveChanges();
    }
}

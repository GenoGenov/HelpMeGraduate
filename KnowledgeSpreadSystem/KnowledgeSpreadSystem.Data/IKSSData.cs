namespace KnowledgeSpreadSystem.Data
{
    using System.Data.Entity;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Data.Common.Repositories;
    using KnowledgeSpreadSystem.Models;

    public interface IKSSData
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }

        IDeletableEntityRepository<CalendarEvent> CalendarEvents { get; }
        
        IDeletableEntityRepository<ChatMessage> ChatMessages { get; }
        
        IDeletableEntityRepository<Course> Courses { get; }

        IDeletableEntityRepository<CourseModule> CourseModules { get; }

        IDeletableEntityRepository<Faculty> Faculties { get; }

        IDeletableEntityRepository<Resource> Resources { get; }
 
        IDeletableEntityRepository<University> Universities { get; }

        IDeletableEntityRepository<Insight> Insigths { get; }

        IDeletableEntityRepository<Rating> Ratings { get; }

        IDeletableEntityRepository<T> GetDeletableGenericRepository<T>() where T : class, IDeletableEntity;

        int SaveChanges();
    }
}

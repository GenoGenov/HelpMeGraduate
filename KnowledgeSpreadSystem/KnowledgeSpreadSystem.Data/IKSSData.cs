using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGallery.Data
{
    using System.Data.Entity;

    using KnowledgeSpreadSystem.Data.Repositories;
    using KnowledgeSpreadSystem.Models;

    public interface IKSSData
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }

        IRepository<CalendarEvent> CalendarEvents { get; }
        
        IRepository<ChatMessage> ChatMessages { get; }
        
        IRepository<Course> Courses { get; }

        IRepository<CourseModule> CourseModules { get; }

        IRepository<Faculty> Faculties { get; }

        IRepository<Resource> Recourses { get; }
 
        IRepository<University> Universities { get; }

        int SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGallery.Data
{
    using KnowledgeSpreadSystem.Data.Repositories;
    using KnowledgeSpreadSystem.Models;

    public interface IKSSData
    {
        IRepository<User> Users { get; }

        IRepository<CalendarEvent> CalendarEvents { get; }
        
        IRepository<ChatMessage> ChatMessages { get; }
        
        IRepository<Course> Courses { get; }

        IRepository<CourseModule> CourseModules { get; }

        IRepository<Facoulty> Facoulties { get; }

        IRepository<Resource> Recourses { get; }
 
        IRepository<University> Universities { get; }

        int SaveChanges();
    }
}

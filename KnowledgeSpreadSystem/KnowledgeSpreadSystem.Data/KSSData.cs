namespace KnowledgeSpreadSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using KnowledgeSpreadSystem.Data.Repositories;
    using KnowledgeSpreadSystem.Models;

    using ProjectGallery.Data;

    public class KSSData : IKSSData
    {
        private DbContext context;

        private IDictionary<Type, object> repositories;

        public KSSData()
            : this(new KSSDBContext())
        {
        }

        public KSSData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<CalendarEvent> CalendarEvents
        {
            get
            {
                return this.GetRepository<CalendarEvent>();
            }
        }

        public IRepository<ChatMessage> ChatMessages
        {
            get
            {
                return this.GetRepository<ChatMessage>();
            }
        }

        public IRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IRepository<CourseModule> CourseModules
        {
            get
            {
                return this.GetRepository<CourseModule>();
            }
        }

        public IRepository<Facoulty> Facoulties
        {
            get
            {
                return this.GetRepository<Facoulty>();
            }
        }

        public IRepository<Resource> Recourses
        {
            get
            {
                return this.GetRepository<Resource>();
            }
        }

        public IRepository<University> Universities
        {
            get
            {
                return this.GetRepository<University>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if(!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}

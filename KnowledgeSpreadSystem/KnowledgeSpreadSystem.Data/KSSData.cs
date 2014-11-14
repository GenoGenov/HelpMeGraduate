namespace KnowledgeSpreadSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Data.Common.Repositories;
    using KnowledgeSpreadSystem.Models;

    public class KSSData : IKSSData
    {


        private IDictionary<Type, object> repositories;

        public KSSData()
            : this(new KSSDBContext())
        {
        }



        public KSSData(DbContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public DbContext Context { get; set; }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IDeletableEntityRepository<CalendarEvent> CalendarEvents
        {
            get
            {
                return this.GetDeletableEntityRepository<CalendarEvent>();
            }
        }

        public IDeletableEntityRepository<ChatMessage> ChatMessages
        {
            get
            {
                return this.GetDeletableEntityRepository<ChatMessage>();
            }
        }

        public IDeletableEntityRepository<Course> Courses
        {
            get
            {
                return this.GetDeletableEntityRepository<Course>();
            }
        }

        public IDeletableEntityRepository<CourseModule> CourseModules
        {
            get
            {
                return this.GetDeletableEntityRepository<CourseModule>();
            }
        }

        public IDeletableEntityRepository<Faculty> Faculties
        {
            get
            {
                return this.GetDeletableEntityRepository<Faculty>();
            }
        }

        public IDeletableEntityRepository<Resource> Recourses
        {
            get
            {
                return this.GetDeletableEntityRepository<Resource>();
            }
        }

        public IDeletableEntityRepository<University> Universities
        {
            get
            {
                return this.GetDeletableEntityRepository<University>();
            }
        }

        public IDeletableEntityRepository<Insight> Insigths
        {
            get
            {
                return this.GetDeletableEntityRepository<Insight>();
            }
        }

        public IDeletableEntityRepository<T> GetDeletableGenericRepository<T>() where T : class, IDeletableEntity
        {
            return this.GetDeletableEntityRepository<T>();
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}

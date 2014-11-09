namespace KnowledgeSpreadSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using ForumSystem.Data.Common.Models;
    using ForumSystem.Data.Common.Repository;

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

        public IDeletableEntityRepository<User> Users
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
                return this.GetRepository<CalendarEvent>();
            }
        }

        public IDeletableEntityRepository<ChatMessage> ChatMessages
        {
            get
            {
                return this.GetRepository<ChatMessage>();
            }
        }

        public IDeletableEntityRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IDeletableEntityRepository<CourseModule> CourseModules
        {
            get
            {
                return this.GetRepository<CourseModule>();
            }
        }

        public IDeletableEntityRepository<Faculty> Faculties
        {
            get
            {
                return this.GetRepository<Faculty>();
            }
        }

        public IDeletableEntityRepository<Resource> Recourses
        {
            get
            {
                return this.GetRepository<Resource>();
            }
        }

        public IDeletableEntityRepository<University> Universities
        {
            get
            {
                return this.GetRepository<University>();
            }
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private IDeletableEntityRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfRepository = typeof(T);
            if(!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(DeletableEntityRepository<T>), this.Context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeOfRepository];
        }
    }
}

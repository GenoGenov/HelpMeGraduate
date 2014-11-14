namespace KnowledgeSpreadSystem.Data.Common.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using KnowledgeSpreadSystem.Data.Common.Models;

    public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public T Find(object id)
        {
            var found = base.Find(id);
            return found == null ? null : found.IsDeleted ? null : found;
        }

        public override void Delete(T entity)
        {
            entity.DeletedOn=DateTime.Now;

            entity.IsDeleted = true;

            var entry = this.Context.Entry(entity);

            entry.State = EntityState.Modified;


        }
    }
}

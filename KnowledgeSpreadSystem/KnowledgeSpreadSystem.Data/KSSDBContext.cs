namespace KnowledgeSpreadSystem.Data
{
    using KnowledgeSpreadSystem.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class KSSDBContext : IdentityDbContext<User>
    {
        public KSSDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static KSSDBContext Create()
        {
            return new KSSDBContext();
        }
    }
}
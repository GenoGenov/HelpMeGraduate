namespace KnowledgeSpreadSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<KSSDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "KnowledgeSpreadSystem.Data.KSSDBContext";
        }

        protected override void Seed(KSSDBContext context)
        {
        }
    }
}

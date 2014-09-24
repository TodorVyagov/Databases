namespace MyStudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MyStudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "MyStudentSystem.Data.MyStudentSystemDbContext";
        }

        protected override void Seed(MyStudentSystemDbContext context)
        {
           
        }
    }
}

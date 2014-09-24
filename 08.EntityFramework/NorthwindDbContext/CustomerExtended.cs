namespace NorthwindDbContext
{
    using System.Data.Linq;

    public partial class Customer
    {
        public EntitySet<Territory> MyTerritory
        {
            get
            {
                EntitySet<Territory> territories = new EntitySet<Territory>();
                territories.AddRange(this.MyTerritory);
                return territories;
            }
        }
    }
}

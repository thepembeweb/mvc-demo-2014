using System.Data.Entity;

namespace MVC.Demo.Models
{
    public class PoiDbContext : DbContext
    {
        public PoiDbContext() : base("PoiDB")
        {
            
        }

        public DbSet<PointOfInterest> PoiSet { get; set; }
    }
}
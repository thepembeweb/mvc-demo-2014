using System.Data.Entity.Spatial;

namespace MVC.Demo.Models
{
    public class PointOfInterest
    {
        public int PointOfInterestId { get; set; }
        public string Name { get; set; }
        public DbGeography Location { get; set; }
    }
}
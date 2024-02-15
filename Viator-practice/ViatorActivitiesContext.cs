using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Viator_practice.Models;

namespace Viator_practice
{
    public class ViatorActivitiesContext : DbContext
    {
        public ViatorActivitiesContext(DbContextOptions<ViatorActivitiesContext> options) 
            : base(options)
        {
        }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Product> Activities { get; set; }
    }
}

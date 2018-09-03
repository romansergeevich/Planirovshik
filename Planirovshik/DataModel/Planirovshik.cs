namespace Planirovshik.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PlanirovshikContext : DbContext
    {
        
        public PlanirovshikContext()
            : base("name=PlanirovshikContext")
        {
        }

        public DbSet<Plan> Plans { get; set; }
    }

}
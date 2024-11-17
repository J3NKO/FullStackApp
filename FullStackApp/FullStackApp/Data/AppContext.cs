using Microsoft.EntityFrameworkCore;
using FullStackApp.Models;


namespace FullStackApp.Data
{ 
    public class AppContext : DbContext
    {

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
            
            public DbSet<Item> Items { get; set; }
    
        

    }

}
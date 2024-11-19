using Microsoft.EntityFrameworkCore;
using FullStackApp.Models;


namespace FullStackApp.Data
{ 
    public class AppContext : DbContext
    {

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        //need to override a method provided by EF core
        //built in EF Core method which takes in a model builder class for data scoping
        //We are initialising/seeding data for the models here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //the collection is of the model type Item
            modelBuilder.Entity<Item>().HasData(
                
                new Item { Id = 4, Name = "Ipad", Price = 400, SerialNumberId = 10}
                
                );

            modelBuilder.Entity<SerialNumber>().HasData(

                new SerialNumber { Id = 10, Name = "Ip100", ItemId = 4 }

                );

            base.OnModelCreating(modelBuilder);
        }


            //The 2 below are our DB Instances
            public DbSet<Item> Items { get; set; }
        
            public DbSet<SerialNumber> SerialNumbers { get; set; }

    }

}
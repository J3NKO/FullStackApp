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


            modelBuilder.Entity<ItemClient>().HasKey(ix => new 
            {

                ix.ItemId,
                ix.ClientId

            });

            modelBuilder.Entity<ItemClient>().HasOne(

                i => i.Item

                ).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);

            modelBuilder.Entity<ItemClient>().HasOne(

                c => c.Client

                ).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ClientId);


            //the collection is of the model type Item
            modelBuilder.Entity<Item>().HasData(
                
                new Item { Id = 4, Name = "Ipad", Price = 400, SerialNumberId = 10}
                
                );

            modelBuilder.Entity<SerialNumber>().HasData(

                new SerialNumber { Id = 10, Name = "Ip100", ItemId = 4 }

                );

            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" }

                );

            base.OnModelCreating(modelBuilder);
        }


            //The 2 below are our DB Instances
            public DbSet<Item> Items { get; set; }
        
            public DbSet<SerialNumber> SerialNumbers { get; set; }

            public DbSet<Category> Categories { get; set; }
            
            public DbSet<Client> Clients { get; set; }

            public DbSet<ItemClient> ItemClients {  get; set; } 


    }


}
namespace FullStackApp.Models
{
    public class ItemClient
    {
        //No Primary Key is required in this Model because it is essentially a mapping table between 2 tables/Models
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public List<ItemClient> ItemClients { get; set; }

    }
}

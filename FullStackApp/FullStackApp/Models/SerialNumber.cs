using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackApp.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? ItemId { get; set; }
        

        //here we are stating that the Item instance will be linked based on the ItemId property
        [ForeignKey("ItemId")]
        public Item? Item { get; set; }
    }
}

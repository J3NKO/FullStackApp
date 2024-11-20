namespace FullStackApp.Models
{
    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;


        //the question mark states this can be nullable
        public List<Item>? Items { get; set; }


    }
}

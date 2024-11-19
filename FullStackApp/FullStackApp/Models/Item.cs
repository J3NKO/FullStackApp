﻿namespace FullStackApp.Models
{
    public class Item
    {
        public int Id { get; set; }

        //properties are defined as not nullable by default
        public string Name { get; set; } = null!;

        public double Price { get; set; }


        //here I have taken a code first data structure approach
        public int? SerialNumberId { get; set; }

        public SerialNumber? SerialNumber { get; set; }


    }
}

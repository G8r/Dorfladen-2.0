using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_Demo.Models
{
    public class Product
    {
        public Product(int id, string name, decimal specialPrice, decimal normalPrice, string imageName, string description)
        {
            Id = id;
            Name = name;
            SpecialPrice = specialPrice;
            NormalPrice = normalPrice;
            ImageName = imageName;
            Description = description;
            Amount = 1;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal SpecialPrice { get; set; }

        public decimal NormalPrice { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }
    }
}
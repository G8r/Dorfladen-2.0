using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_Demo.Models
{
    public class Product
    {
        private int _id;
        private string _name;
        private decimal _specialPrice;
        private decimal _normalPrice;
        private string _imageName;
        private string _description;
        private int _amount;

        public Product() { }

        public Product(int id, string name, decimal specialPrice, decimal normalPrice, string imageName, string description)
        {
            _id = id;
            _name = name;
            _specialPrice = specialPrice;
            _normalPrice = normalPrice;
            _imageName = imageName;
            _description = description;
            _amount = 1;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public decimal SpecialPrice { get => _specialPrice; set => _specialPrice = value; }
        public decimal NormalPrice { get => _normalPrice; set => _normalPrice = value; }
        public string ImageName { get => _imageName; set => _imageName = value; }
        public string Description { get => _description; set => _description = value; }
        public int Amount { get => _amount; set => _amount = value; }
    }
}
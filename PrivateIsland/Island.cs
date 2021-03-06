﻿
namespace PrivateIsland
{
    public class Island
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public int Acres { get; set; }
        public int Price { get; set; }
        public bool ForSale { get; set; }
        
        public Island(int id,string name,string desc,string img,string location,int acres,int price,bool forsale)
        {
            ID = id;
            Name = name;
            Description = desc;
            ImageUrl = img;
            Location = location;
            Acres = acres;
            Price = price;
            ForSale = forsale;
        }
    }
}
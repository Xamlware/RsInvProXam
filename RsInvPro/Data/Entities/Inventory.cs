using System;
namespace RsInvPro.Data.Entities
{
    public class Inventory
    {
        //[Key]
        public int PK_Inventory { get; set; }

        public string SKU { get; set; }

        public string Item { get; set; }

        public Department Department { get; set; }

        public Category Category { get; set; }

        public SubCategory SubCategory { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SellPrice { get; set; }

        public Brand Brand { get; set; }

        public string Location { get; set; }



        public Inventory() { }
        public Inventory(int id, string sku, string name,
                         Department department, Category cat, SubCategory sub,
                         DateTime purchaseDate, decimal purPrice, decimal sellPrice,
                         Brand brand, string loc)
        {
            this.PK_Inventory = id;
            this.SKU = sku;
            this.Item = name;
            this.PurchaseDate = purchaseDate;
            this.Department = department;
            this.Category = cat;
            this.SubCategory = sub;
            this.Brand = brand;
            this.Location = loc;
            this.PurchasePrice = purPrice;
            this.SellPrice = sellPrice;

        }
       
    }


}

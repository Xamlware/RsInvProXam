using System;
using System.ComponentModel.DataAnnotations;

namespace RsInvPro.Data.Entities
{
    public class Inventory
    {
        [Key]
        [Display(Name = "Id")]
        public int PK_Inventory { get; set; }

        public string SKU { get; set; }

        public string Item { get; set; }

        [Display(Name = "Brand", Prompt="Select Brand")]         
        public int FK_Brand { get; set; }

        [Display(Name = "Dept", Prompt = "Select Dept")]
        public int FK_Department { get; set; }

        [Display(Name = "Cat", Prompt = "Select Cat")]
        public int FK_Category { get; set; }

        [Display(Name = "SubCat", Prompt = "Select SubCat")]
        public int FK_SubCategory { get; set; }

        [Display(Name = "Pur Date", Prompt = "Select Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Pur Price", Prompt = "Enter Pur Price")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Sell Price", Prompt = "Enter Sell Price")]
        public decimal SellPrice { get; set; }

        [Display(Name = "Loc", Prompt = "Enter Location")]
        public string Location { get; set; }



        public Inventory() { }
        public Inventory(int id, string sku, string name,
                         int FK_Department, int FK_Category , int FK_SubCategory,
                         DateTime purchaseDate, decimal purPrice, decimal sellPrice,
                         int FK_Brand, string loc)
        {
            this.PK_Inventory = id;
            this.SKU = sku;
            this.Item = name;
            this.PurchaseDate = purchaseDate;
            this.FK_Department = FK_Department;
            this.FK_Category = FK_Category;
            this.FK_SubCategory = FK_SubCategory;
            this.FK_Brand = FK_Brand;
            this.Location = loc;
            this.PurchasePrice = purPrice;
            this.SellPrice = sellPrice;

        }
       
    }


}

using System;
namespace RsInvPro.Data.Entities
{
    public class InventorySold
    {
        public int PK_InventorySold {get;set;}

        public int PK_Inventory { get; set; }

        public string SKU { get; set; }

        public string Item { get; set; }

        public DateTime PurchaseDate { get; set; }

        public float PurchasePrice { get; set; }

        public Brand Brand { get; set; }

        public string Location { get; set; }

        public DateTime SellDate { get; set; }

        public float SellPrice { get; set; }


        public InventorySold()
        {
        }
    }
}

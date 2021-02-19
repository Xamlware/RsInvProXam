using System;
namespace RsInvPro.Data.Entities
{
    public class InventoryItem
    {
        //[Key]
        public int PK_InventoryItem { get; set; }

        //[Required(ErrorMessage = "Region id is required")]
        public int FK_Inventory { get; set; }

        public InventoryItem(int id, int inventoryId)
        {
            PK_InventoryItem = id;
            FK_Inventory = inventoryId;
        }
    }
}

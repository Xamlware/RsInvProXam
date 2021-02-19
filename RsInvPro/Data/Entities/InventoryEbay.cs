using System;
namespace RsInvPro.Data.Entities
{
    public class InventoryEbay
    {
        //[Key]
        public int PK_InventoryEbay { get; set; }

        //[Required(ErrorMessage = "Region id is required")]
        public int FK_Inventory { get; set; }


    }
}

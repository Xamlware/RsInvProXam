using System;
namespace RsInvPro.Data.Entities
{
	public class InventoryPoshmark
	{

		//[Key]
		public int PK_InventoryPoshmark { get; set; }

		//[Required(ErrorMessage = "Region id is required")]
		public int FK_Inventory { get; set; }

	}
}

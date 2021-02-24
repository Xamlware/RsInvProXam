using System;
using RsInvPro.Data.Entities;

namespace RsInvPro.Messages
{
    public class SelectedItemResponseMessage
    {
        public Inventory Item { get; set; }
        public SelectedItemResponseMessage()
        {
        }
    }
}

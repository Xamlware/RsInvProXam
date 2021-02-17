using System;
using GalaSoft.MvvmLight;

namespace RsInvPro.ViewModels
{
    public class InventoryColumnViewModel : ViewModelBase
    {
        public string ColumnHeader { get; private set; } = "Welcome to columns";
        public InventoryColumnViewModel()
        {
        }
    }
}

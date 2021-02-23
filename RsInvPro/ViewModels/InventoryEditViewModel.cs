using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using RsInvPro.Data.Entities;
using RsInvPro.Services.DataServices;

namespace RsInvPro.ViewModels
{
    public class InventoryEditViewModel : ViewModelBase
    {
        private readonly INavigationService _navService;
        private readonly IDataService<Inventory> _ds;



        #region Commands

        #endregion

        #region Properties
        public const string InventoryRowProperty = "InventoryRowProperty";
        private Inventory _inventoryRow;
        public Inventory InventoryRow
        {
            get
            {
                return _inventoryRow;
            }
            set
            {
                _inventoryRow = value;
                this.RaisePropertyChanged(InventoryRowProperty);
            }
        }
        #endregion

        public InventoryEditViewModel(INavigationService navService, IDataService<Inventory> ds)
        {
            _navService = navService;
            _ds = ds;

            var type = new Inventory();
            this.InventoryRow = _ds.GetSqlTableRow(type, 2, true);




        }
    }
}

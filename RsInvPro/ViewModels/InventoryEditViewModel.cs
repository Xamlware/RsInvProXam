using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using RsInvPro.Data.Entities;
using RsInvPro.Messages;
using RsInvPro.Services.DataServices;

namespace RsInvPro.ViewModels
{
    public class InventoryEditViewModel : ViewModelBase
    {
        private readonly INavigationService _navService;
        private readonly IDataService<Inventory> _ds;
        private readonly InventoryViewModel _invVm;

        public InventoryEditViewModel(INavigationService navService, IDataService<Inventory> ds)
        {

            _navService = navService;
            _ds = ds;
            _invVm = SimpleIoc.Default.GetInstance<InventoryViewModel>();
            this.InventoryRow = _invVm.SelectedItem;

            //Messenger.Default.Send(new GetSelectedItemMessage());
            //Messenger.Default.Register<SelectedItemResponseMessage>(this, HandleSelectedItemResponseMessage);


            //this.InventoryRow = _ds.GetSqlTableRow(new Inventory(), 2, true);

        }

        private void HandleSelectedItemResponseMessage(SelectedItemResponseMessage msg)
        {
            this.InventoryRow = (Inventory)msg.Item;
        }


        #region Commands        #region Commands

        private RelayCommand _saveChangesCommand;
        public RelayCommand SaveChangesCommand
        {
            get { return _saveChangesCommand; }
            protected set { _saveChangesCommand = value; }
        }

        private RelayCommand _cancelChangesCommand;
        public RelayCommand CancelChangesCommand
        {
            get { return _cancelChangesCommand; }
            protected set { _cancelChangesCommand = value; }
        }
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

    }
}

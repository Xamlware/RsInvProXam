using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using RsInvPro.Services;

namespace RsInvPro.ViewModels
{


    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navService;

        public RelayCommand inventoryPageCommand { get; private set; }

        public string HelloWorldString { get; private set; } = "Hello from Xamarin Forms";



        public MainViewModel(INavigationService navService)
        {
            //InventoryPageCommand = new RelayCommand(
            //   () => ExecuteInventoryPageCommnd(),
            //   () => CanExecuteInventoryPageCommnd());

            _navService = navService;
        }

        public RelayCommand InventoryPageCommand
        {
            get
            {
                return inventoryPageCommand
                       ?? (inventoryPageCommand = new RelayCommand(

                              () => ExecuteInventoryPageCommnd(),
                              () => CanExecuteInventoryPageCommnd()));
            }
        }

        private bool CanExecuteInventoryPageCommnd()
        {
            return true;

        }

        private void ExecuteInventoryPageCommnd()
        {

            _navService.NavigateTo(ViewModelLocator.InventoryPage);

        }

    }

}

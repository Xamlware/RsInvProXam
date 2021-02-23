using System;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using RsInvPro.DataServices;
using RsInvPro.Services;
using RsInvPro.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RsInvPro
{
    public partial class App : Application
    {
        private static ViewModelLocator _viewModelLocator;
        private string dbPath;

        public static ViewModelLocator ViewModelLocator
        {
            get
            {
                return _viewModelLocator ?? (_viewModelLocator = new ViewModelLocator());
            }
        }


        public App()
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzk5Njc2QDMxMzgyZTM0MmUzMGVKYy9WMUNnYlF4MWc5T0FWTG0vcVFydmplcXcxSW1KNkRVb2x3bFVTbFE9");
            InitializeComponent();


            // First time initialization
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.MainPage, typeof(MainView));
            nav.Configure(ViewModelLocator.InventoryPage, typeof(InventoryView));
            nav.Configure(ViewModelLocator.InventoryEditPage, typeof(InventoryEditView));
            nav.Configure(ViewModelLocator.InventoryColumnPage, typeof(InventoryColumnView));
            SimpleIoc.Default.Register<INavigationService>(() => nav);

            //var dialog = new DialogService();
            //SimpleIoc.Default.Register<IDialogService>(() => (IDialogService)dialog);
            ////SimpleIoc.Default.Register<IDataService<T>>(() => (IDialogService)dialog);

            var navPage = new NavigationPage(new MainView());

            nav.Initialize(navPage);
            //dialog.Initialize(navPage);

            // The root page of your application
            MainPage = navPage;
        }

        public App(string dbPath)
        {
            this.dbPath = dbPath;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

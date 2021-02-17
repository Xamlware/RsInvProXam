using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using RsInvPro.Data.Entities;
using RsInvPro.DataServices;
using RsInvPro.Services.DataServices;
using RsInvPro.ViewModels;

namespace RsInvPro.Services
{
    public class ViewModelLocator
    {
        private const bool ForceDesignData = false;
        public const string MainPage = "MainPage";
        public const string InventoryPage = "InventoryPage";
        public const string InventoryColumnsPage = "InventoryColumnsPage";



        static ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<InventoryViewModel>();
            SimpleIoc.Default.Register<InventoryColumnViewModel>();

            SimpleIoc.Default.Register<IDataService<Inventory>, DataService<Inventory>>();
            SimpleIoc.Default.Register<IDataService<InventoryItem>, DataService<InventoryItem>>();
            SimpleIoc.Default.Register<IDataService<InventoryEbay>, DataService<InventoryEbay>>();
            SimpleIoc.Default.Register<IDataService<InventoryPoshmark>, DataService<InventoryPoshmark>>();

        }

        [SuppressMessage("Microsoft.Performance",
           "CA1822:MarkMembersAsStatic",
           Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<MainViewModel>())
                {
                    SimpleIoc.Default.Register<MainViewModel>();
                }
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }

        [SuppressMessage("Microsoft.Performance",
          "CA1822:MarkMembersAsStatic",
          Justification = "This non-static member is needed for data binding purposes.")]
        public InventoryViewModel InventoryViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<InventoryViewModel>())
                {
                    SimpleIoc.Default.Register<InventoryViewModel>();
                }
                return SimpleIoc.Default.GetInstance<InventoryViewModel>();
            }
        }

        [SuppressMessage("Microsoft.Performance",
          "CA1822:MarkMembersAsStatic",
          Justification = "This non-static member is needed for data binding purposes.")]
        public InventoryColumnViewModel InventoryColumnsViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<InventoryColumnViewModel>())
                {
                    SimpleIoc.Default.Register<InventoryColumnViewModel>();
                }
                return SimpleIoc.Default.GetInstance<InventoryColumnViewModel>();
            }
        }
    }
}

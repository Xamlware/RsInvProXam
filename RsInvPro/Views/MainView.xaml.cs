using GalaSoft.MvvmLight.Ioc;
using RsInvPro.ViewModels;
using Xamarin.Forms;

namespace RsInvPro.Views
{
    public partial class MainView : ContentPage
    {
        MainViewModel vm = SimpleIoc.Default.GetInstance<MainViewModel>();

        public MainView()
        {
            InitializeComponent();
            this.BindingContext = vm;

            NavigateButton.Clicked += (s, e) =>
            {
                vm.InventoryPageCommand.Execute(new object());
            };
        }
    }
}

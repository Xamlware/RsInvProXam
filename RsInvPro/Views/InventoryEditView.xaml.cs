using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using RsInvPro.ViewModels;
using Syncfusion.XForms.DataForm;
using Xamarin.Forms;

namespace RsInvPro.Views
{
    public partial class InventoryEditView : ContentPage
    {
        InventoryEditViewModel vm = SimpleIoc.Default.GetInstance<InventoryEditViewModel>();


        public InventoryEditView()
        {
            //dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;

            InitializeComponent();


            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;
            //this.BindingContext = vm;


        }


        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem.Name == "PK_Inventory")
                e.DataFormItem.IsReadOnly = true;
        }
    }
}

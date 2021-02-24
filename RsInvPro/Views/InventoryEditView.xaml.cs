using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using RsInvPro.Messages;
using RsInvPro.ViewModels;
using Xamarin.Forms;

namespace RsInvPro.Views
{
    public partial class InventoryEditView : ContentPage
    {
        private readonly InventoryViewModel _ivm;

        public InventoryEditView()
        {
            InitializeComponent();
 
            _ivm = SimpleIoc.Default.GetInstance<InventoryViewModel>();
        }

      
    }
}

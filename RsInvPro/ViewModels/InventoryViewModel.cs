using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using RsInvPro.Data.Entities;
using RsInvPro.Helpers;
using RsInvPro.Messages;
using RsInvPro.Services;
using RsInvPro.Services.DataServices;
using Syncfusion.SfDataGrid.XForms;

namespace RsInvPro.ViewModels
{
    public class InventoryViewModel : ViewModelBase
	{
		private readonly INavigationService _navService;
		private readonly IDataService<Inventory> _ds;
		public static bool IsDesignModeEnabled { get; }

		public InventoryViewModel(INavigationService navService, IDataService<Inventory> ds)
		{

			_ds = ds;
			_navService = navService;
			Messenger.Default.Register<GetSelectedItemMessage>(this, HandleGetSelectedItemMessage);
			

			this.InventoryList = this.GetInventoryList();
			this.InventoryHeader = "Hello from our inventory page";
			this.SelectedIndex = 0;
			this.IsInventoryIdHidden = false;
			this.IsInventoryNameidden = false;
			this.IsInventorySkuHidden = false;


			this.InventoryAddCommand = new RelayCommand(
				() => ExecuteInventoryAddCommnd(),
				() => CanExecuteInventoryAddCommnd());

			this.InventoryEditCommand = new RelayCommand(
				() => ExecuteInventoryEditCommnd(),
				() => CanExecuteInventoryEditCommnd());

			SelectionCommand = new RelayCommand<GridSelectionChangedEventArgs>(i => ExecuteSelectionCommnd(i),
				i=>CanExecuteSelectionCommnd());
		}

		private void HandleGetSelectedItemMessage(GetSelectedItemMessage obj)
		{

			Messenger.Default.Send(new SelectedItemResponseMessage { Item = this.SelectedItem });
        }


		private void SetInventoryRow(Inventory item)
        {
			InventoryEditViewModel ievm = SimpleIoc.Default.GetInstance <InventoryEditViewModel>();
			ievm.InventoryRow = item;
        }


		private Inventory GetInventoryRecord()
		{
			//return _ds.GetTableList(IsDesignModeEnabled, inventory, "Get", "api/district/");
			return _ds.GetSqlTableRow(new Inventory(), 2, true);
		}

		private bool CanExecuteInventoryAddCommnd()
		{
			return true;
		}

		private void ExecuteInventoryAddCommnd()
		{
			_navService.NavigateTo(ViewModelLocator.InventoryEditPage);
		}

		private bool CanExecuteInventoryEditCommnd()
		{
			return this.SelectedItem != null;
		}

		private void ExecuteInventoryEditCommnd()
		{
			_navService.NavigateTo(ViewModelLocator.InventoryEditPage);
		}


		private bool CanExecuteSelectionCommnd()
		{
			return true;
		}

		private void ExecuteSelectionCommnd(GridSelectionChangedEventArgs e)
        {
			this.SelectedItem = (Inventory) e.AddedItems;
		}

		public ObservableCollection<Inventory> GetInventoryList()
		{

			//return _ds.GetTableList(IsDesignModeEnabled, inventory, "Get", "api/district/");
			//var inv = _ds.GetSqlTableRow(new Inventory(), 2, true);
			return _ds.GetSqlTableList(new Inventory(), null, true).ToCollection();


		}


		#region Commands

		private RelayCommand inventoryAddCommand;
		public RelayCommand InventoryAddCommand
		{
			get { return inventoryAddCommand; }
			protected set { inventoryAddCommand = value; }
		}

		private RelayCommand _inventoryEditCommand;
		public RelayCommand InventoryEditCommand
		{
			get { return _inventoryEditCommand; }
			protected set { _inventoryEditCommand = value; }
		}

		private RelayCommand<GridSelectionChangedEventArgs> _selectionCommand;
		public RelayCommand<GridSelectionChangedEventArgs> SelectionCommand
		{
			get { return _selectionCommand; }
			protected set { _selectionCommand = value; }
		}

		#endregion

		#region Properties
		public const string InventoryHeaderProperty = "InventoryHeaderProperty";
		private string _inventoryHeader;
		public string InventoryHeader
		{
			get
			{
				return _inventoryHeader;
			}
			set
			{
				_inventoryHeader = value;
				this.RaisePropertyChanged(InventoryHeaderProperty);
			}
		}


		public const string InventoryListProperty = "InventoryListProperty";
		private ObservableCollection<Inventory> _inventoryList;
		public ObservableCollection<Inventory> InventoryList
		{
			get
			{
				return _inventoryList;
			}
			set
			{
				_inventoryList = value;
				this.RaisePropertyChanged(InventoryListProperty);
			}
		}

		public const string SelectedItemProperty = "SelectedItemProperty";
		private Inventory _selectedItem ;
		public Inventory SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem = value;
				this.RaisePropertyChanged(SelectedItemProperty);
				this.InventoryEditCommand.RaiseCanExecuteChanged();
				this.SetInventoryRow(value);

			}
		}

		public const string SelectedIndexProperty = "SelectedIndexProperty";
		private int _selectedIndex;
		public int SelectedIndex
		{
			get
			{
				return _selectedIndex;
			}
			set
			{
				_selectedIndex = value;
				this.RaisePropertyChanged(SelectedIndexProperty);
			}
		}

		#region Hiding colums definition

		public const string IsInventoryIdHiddenProperty = "IsInventoryIdHiddenProperty";
		private bool _isInventoryIdHidden;
		public bool IsInventoryIdHidden
		{
			get
			{
				return _isInventoryIdHidden;
			}
			set
			{
				_isInventoryIdHidden = value;
				this.RaisePropertyChanged(IsInventoryIdHiddenProperty);
			}
		}

		public const string IsInventorySkuHiddenProperty = "IsInventorySkuHiddenProperty";
		private bool _isInventorySkuHidden;
		public bool IsInventorySkuHidden
		{
			get
			{
				return _isInventorySkuHidden;
			}
			set
			{
				_isInventorySkuHidden = value;
				this.RaisePropertyChanged(IsInventorySkuHiddenProperty);
			}
		}

		public const string IsInventoryNameiddenProperty = "IsInventoryNameiddenProperty";
		private bool _isInventoryNameidden;
		public bool IsInventoryNameidden
		{
			get
			{
				return _isInventoryNameidden;
			}
			set
			{
				_isInventoryNameidden = value;
				this.RaisePropertyChanged(IsInventoryNameiddenProperty);
			}
		}
		#endregion
		#endregion



	}


}


//private ICommand selectionCommand;
//public ICommand SelectionCommand
//{
//	get { return selectionCommand; }
//	set { selectionCommand = value; }
//}
//public ViewModel()
//{
//	selectionCommand = new Command<GridSelectionChangedEventArgs>(OnSelectionChanged);

		 
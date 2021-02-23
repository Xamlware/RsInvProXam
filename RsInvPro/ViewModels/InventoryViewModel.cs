using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using RsInvPro.Data.Entities;
using RsInvPro.DataServices;
using RsInvPro.Helpers;
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

		#region Commands

			private RelayCommand inventoryAddCommand;
			public RelayCommand InventoryAddCommand
			{
				get { return inventoryAddCommand; }
				protected set { inventoryAddCommand = value; }
			}

		private RelayCommand<Inventory> inventoryEditCommand;
		public RelayCommand<Inventory> InventoryEditCommand
		{
			get { return inventoryEditCommand; }
			protected set { inventoryEditCommand = value; }
		}

		private RelayCommand<GridSelectionChangedEventArgs> selectionCommand;
			public RelayCommand<GridSelectionChangedEventArgs> SelectionCommand
			{
				get { return selectionCommand; }
				protected set { selectionCommand = value; }
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
		private ObservableCollection<Inventory> _selectedItem;
		public ObservableCollection<Inventory> SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem = value;
				this.RaisePropertyChanged(SelectedItemProperty);
			}
		}

		public const string SelectedIndexProperty = "SelectedIndexProperty";
		private ObservableCollection<Inventory> _selectedIndex;
		public ObservableCollection<Inventory> SelectedIndex
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


		public InventoryViewModel(INavigationService navService, IDataService<Inventory> ds)
		{

			_ds = ds;
			_navService = navService;

			this.InventoryList = this.GetInventoryList();
			this.InventoryHeader = "Hello from our inventory page";
			this.IsInventoryIdHidden = false;
			this.IsInventoryNameidden = false;
			this.IsInventorySkuHidden = false;


			this.InventoryAddCommand = new RelayCommand(
				() => ExecuteInventoryAddCommnd(),
				() => CanExecuteInventoryAddCommnd());

			this.InventoryEditCommand = new RelayCommand<Inventory>(
				i => ExecuteInventoryEditCommnd(i),
				i => CanExecuteInventoryEditCommnd());

			SelectionCommand = new RelayCommand<GridSelectionChangedEventArgs>(i => ExecuteSelectionCommnd(i),
				i=>CanExecuteSelectionCommnd());
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
			var inv = new Inventory();
            _navService.NavigateTo(ViewModelLocator.InventoryEditPage, inv);
		}

		private bool CanExecuteInventoryEditCommnd()
		{
			return true;
		}

		private void ExecuteInventoryEditCommnd(Inventory i)
		{
			_navService.NavigateTo(ViewModelLocator.InventoryEditPage, this.SelectedItem);
		}


		private bool CanExecuteSelectionCommnd()
		{
			return true;
		}

		private void ExecuteSelectionCommnd(GridSelectionChangedEventArgs e)
        {
			this.SelectedItem = (ObservableCollection<Inventory>) e.AddedItems;

		}

		public ObservableCollection<Inventory> GetInventoryList()
		{

			//return _ds.GetTableList(IsDesignModeEnabled, inventory, "Get", "api/district/");
			//var inv = _ds.GetSqlTableRow(new Inventory(), 2, true);
			return _ds.GetSqlTableList(new Inventory(), null, true).ToCollection();


		}
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

		 
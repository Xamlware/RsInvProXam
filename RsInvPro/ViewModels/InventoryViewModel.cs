using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using RsInvPro.Data.Entities;
using RsInvPro.DataServices;
using RsInvPro.Services.DataServices;

namespace RsInvPro.ViewModels
{
	public class InventoryViewModel : ViewModelBase
	{
		private readonly INavigationService _navService;
		private readonly IDataService<Inventory> _ds;
		public static bool IsDesignModeEnabled { get; }

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




		public InventoryViewModel(IDataService<Inventory> ds)
		{
			_ds = ds;
			this.InventoryList = this.GetInventoryList();
			this.InventoryHeader = "Hello from our inventory page";
			this.IsInventoryIdHidden = true;
			this.IsInventoryNameidden = true;
			this.IsInventorySkuHidden = false;
		}

		public ObservableCollection<Inventory> GetInventoryList()
		{

			//return _ds.GetTableList(IsDesignModeEnabled, inventory, "Get", "api/district/");
			return _ds.GetSqlTableList(new Inventory(), null);

		}
	}
}

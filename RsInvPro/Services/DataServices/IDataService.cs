using System;
using System.Collections.ObjectModel;

namespace RsInvPro.Services.DataServices
{
	public interface IDataService<T>
	{
		T UpdateTable<T>(bool isDesign, T t, string method, string route, int? id) where T : class;

		ObservableCollection<T> GetApiTableList(bool isDesign, T t, string method, string route);
		ObservableCollection<T> GetSqlTableList(T t, int? Id);
	}
}

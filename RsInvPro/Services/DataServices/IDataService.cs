using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RsInvPro.Services.DataServices
{
	public interface IDataService<T>
	{
		T UpdateTable<T>(bool isDesign, T t, string method, string route, int? id) where T : class;

		ObservableCollection<T> GetApiTableList(bool isDesign, T t, string method, string route);
		IList<T> GetSqlTableList(T t, int? Id, bool? isDesign);
	}
}

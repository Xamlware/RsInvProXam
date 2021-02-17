using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using RsInvPro.Data.Entities;
using Newtonsoft.Json;

namespace RsInvPro.DataServices
{
	public class ExecuteDataRequest
	{
		public async Task<string> ExecuteRequest(bool isDesign, string route, string method, string content = null, int? id = null)
		{
			string result = null;
			StringContent pContent = null;

			if (isDesign)
			{

				if (route.ToLower().Contains("inventory"))
				{
					var list = new ObservableCollection<Inventory>()
					{
						//new Inventory(1, "1Sku", "This is item 1"),
						//new Inventory(2, "2Sku", "This is item 2"),
						//new Inventory(3, "3Sku", "This is item 3")
					};
					return JsonConvert.SerializeObject(list);
				}
			}
			else
			{
				using (var client = new System.Net.Http.HttpClient())
				{
					try
					{
						// Setting Base address.  
						client.BaseAddress = new Uri("https://localhost:5001/");

						// Setting content type.  
						client.DefaultRequestHeaders.Accept.Clear();
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

						// Setting timeout.  
						client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

						HttpResponseMessage response = new HttpResponseMessage();
						switch (method)
						{
							case "Post":
								pContent = new StringContent(content, Encoding.UTF8, "application/json");
								response = client.PostAsync(route, pContent).GetAwaiter().GetResult();
								break;
							case "Put":
								pContent = new StringContent(content, Encoding.UTF8, "application/json");
								response = client.PutAsync(route + id.ToString(), pContent).GetAwaiter().GetResult();
								break;
							case "Delete":
								response = client.DeleteAsync(route + id.ToString()).GetAwaiter().GetResult();
								break;
							case "Get":
								response = client.GetAsync(route).GetAwaiter().GetResult();
								break;
							default:
								break;
						}

						// Verification  
						if (response.IsSuccessStatusCode)
						{
							result = response.Content.ReadAsStringAsync().Result;

							// Releasing.  
							response.Dispose();
						}
						else
						{
							// Reading Response.  
							result = response.Content.ReadAsStringAsync().Result;
							//responseObj.code = 602;
						}

					}

					catch (Exception ex)
					{
						throw ex;
					}

					return result;
				}

			}

			return null;
		}
	}
}
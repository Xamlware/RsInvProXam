﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RsInvPro.Data;
using RsInvPro.Data.Entities;
using RsInvPro.Helpers;
using RsInvPro.Services.DataServices;

namespace RsInvPro.DataServices
{
    public class DataService<T> : IDataService<T>
    {

        ExecuteDataRequest edr = new ExecuteDataRequest();
        //OfflineContext _dbOffline = new OfflineContext();
        //IUnitOfWork unitOfWork = new UnitOfWork(new OfflineContext());
        //ISyncService _ss = SimpleIoc.Default.GetInstance<ISyncService>();



#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public T UpdateTable<T>(bool isDesign, T t, string method, string route = "", int? id = null) where T : class
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            return default(T);

        }


        public ObservableCollection<T> GetApiTableList(bool isDesign, T t, string method, string route)
        {

            try
            {

                if (t is Inventory)
                {
                    var task = edr.ExecuteRequest(isDesign, route, method);
                    if (task.Result.Contains("Exception"))
                    {
                        return null;
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<T>>(task.Result);
                    }
                }
                else if (t is InventoryItem)
                {
                    var task = edr.ExecuteRequest(isDesign, route, method);
                    if (task.Result.Contains("Exception"))
                    {
                        return null;
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<T>>(task.Result);
                    }
                }


            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public IList<T> GetSqlTableList(T t, int? id, bool? isDesign)
        {
            if ((bool)isDesign.IsTrue())
            {
                List<Inventory> inventory = new List<Inventory>();
                inventory.Add(new Inventory(1, "1k SkU", "Item 1", new Department("Item 1 Department"),
                                           new Category("Item 1 Category"), new SubCategory("Item 1 Subcategory"),
                                           DateTime.Parse("1/1/2021"),
                                           (decimal)1.11, (decimal)11.11, new Brand("Brand 1"), "A11"));

                inventory.Add(new Inventory(2, "2k SkU", "Item 2", new Department("Item 2 Department"),
                                            new Category("Item 2 Category"), new SubCategory("Item 2 Subcategory"),
                                            DateTime.Parse("2/2/2021"),
                                            (decimal)2.22, (decimal)22.22, new Brand("Brand 2"), "A22"));
                return (IList<T>)inventory;
                
            }
            else
            {
                //using (var db = new ApplicationDbContext())
                //{

                    //The line below clears and resets the databse.
                    //db.Database.EnsureDeleted();

                    //// Create the database if it does not exist
                    //db.Database.EnsureCreated();


                    try
                    {

                        //if (t is Inventory)
                        //{
                        //    ObservableCollection<Inventory> invList;
                        //    invList = db.Inventory.Select(i => i).OrderBy(i => i.Item).ToCollection<Inventory>();

                        //}
                        //else if (t is InventoryItem)
                        //{
                        //    ObservableCollection<InventoryItem> invList;
                        //    invList = db.InventoryItem.Where(w => w.FK_Inventory == id).ToCollection<InventoryItem>();
                        //}


                    }
                    catch (Exception e)
                    {
                        return null;
                    }

                    return null;
                //}
            }
        }
    }
}



using System;
using System.Collections.ObjectModel;

namespace RsInvPro.Data.Entities
{
    public class InventoryColumn
    {
        public string ColumnName { get; set; }
        public string TableName { get; set; }
        public bool IsHidden { get; set; }
        public int Order { get; set; }

        public InventoryColumn(string column, string table, bool hidden, int order)
        {
            this.ColumnName = column;
            this.TableName = table;
            this.IsHidden = hidden;
            this.Order = order;


            
        }
    }

}

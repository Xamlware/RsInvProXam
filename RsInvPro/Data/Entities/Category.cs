using System;
using System.ComponentModel.DataAnnotations;

namespace RsInvPro.Data.Entities
{
    public class Category
    {
        [Key]
        public int PK_Category { get; set; }

        public string CategoryName { get; set; }

        public Category(int id, string name)
        {
            PK_Category = id;
            CategoryName = name;

        }
    }
}

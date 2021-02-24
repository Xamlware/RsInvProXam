using System;
using System.ComponentModel.DataAnnotations;

namespace RsInvPro.Data.Entities
{
    public class SubCategory
    {
        [Key]
        public int PK_SubCategory { get; set; }
        public string SubCategoryName { get; set; }

        public SubCategory(int id, string name)
        {
            PK_SubCategory = id;
            SubCategoryName = name;

        }
    }
}

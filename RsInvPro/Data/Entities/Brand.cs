using System;
using System.ComponentModel.DataAnnotations;

namespace RsInvPro.Data.Entities
{
    public class Brand
    {
        [Key]
        public int PK_Brand { get; set; }
        public string BrandName { get; set; }

        public Brand(int id, string name)
        {
            PK_Brand = id;
            BrandName = name;

        }
    }
}

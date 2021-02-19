using System;
namespace RsInvPro.Data.Entities
{
    public class Category
    {

        public string CategoryName { get; set; }

        public Category(string name)
        {
            CategoryName = name;

        }
    }
}

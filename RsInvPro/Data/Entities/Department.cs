using System;
namespace RsInvPro.Data.Entities
{
    public class Department
    {

        public string DepartmentName { get; set; }

        public Department(string name)
        {
            DepartmentName = name;
           
        }
    }
}

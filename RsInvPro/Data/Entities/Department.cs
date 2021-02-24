using System;
using System.ComponentModel.DataAnnotations;

namespace RsInvPro.Data.Entities
{
    public class Department
    {
        [Key]
        public int PK_Department { get; set; }
        public string DepartmentName { get; set; }

        public Department(int id, string name)
        {
            PK_Department = id;
            DepartmentName = name;
           
        }
    }
}

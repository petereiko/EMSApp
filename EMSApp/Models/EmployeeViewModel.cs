using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSApp.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Address { get; set; }
    }
}
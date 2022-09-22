using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMSApp.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="Please enter Name as it is compulsory",AllowEmptyStrings =false)]
        public string Name { get; set; }

        [Required]
        public int? Age { get; set; }

        [Display(Name="Department")]
        [Required]
        public int? DepartmentId { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMvcCrudService.Models
{
    public class mvcEmployeemodel
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage ="THIS Field is required")]
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}
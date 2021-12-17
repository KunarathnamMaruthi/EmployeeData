using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EmployeeData.Models
{
    public partial class Employee
    { [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
      
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "FirstName")]
        public DateTime DateOfJoning { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "PhoneNo")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

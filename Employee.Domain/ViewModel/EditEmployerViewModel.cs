using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee.Domain.ViewModel
{
    public class EditEmployerViewModel
    {

        public int Id { get; set; }
        [Required, MinLength(4)]

        public string UserName { get; set; }


        [Required(ErrorMessage = "First Name is a Required field.")]
        [DataType(DataType.Text)]
        [Display(Order = 1, Name = "FirstName")]
        [RegularExpression("^((?!^FirstName$)[a-zA-Z '])+$", ErrorMessage = "First name is required and must be properly formatted.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is a Required field.")]
        [DataType(DataType.Text)]
        [Display(Order = 1, Name = "LastName")]
        [RegularExpression("^((?!^LastName$)[a-zA-Z '])+$", ErrorMessage = "LastName is required and must be properly formatted.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone is a Required field.")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression("^[01]?[- .]?\\(?[2-9]\\d{2}\\)?[- .]?\\d{3}[- .]?\\d{4}$",
        //ErrorMessage = "Phone is required and must be properly formatted.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Display(Name = "Department")]
        public int DepartId { get; set; }
        public Department Departments { get; set; }
    }
}

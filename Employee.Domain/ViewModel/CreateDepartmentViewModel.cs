using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Domain.ViewModel
{
    public class CreateDepartmentViewModel
    {
        [Required(ErrorMessage = "DepartName is a Required field.")]
        [DataType(DataType.Text)]
        [RegularExpression("^((?!^DepartName$)[a-zA-Z '])+$", ErrorMessage = "DepartName is required and must be properly formatted.")]
        public string DepartName { get; set; }

        [Required(ErrorMessage = "DepartNo is a Required field.")]

        public int DepartNo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
    }
}

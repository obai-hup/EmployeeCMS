using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Web.ViewModel
{
    public class EditDepartViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "DepartName is a Required field.")]
        [DataType(DataType.Text)]
        [RegularExpression("^((?!^DepartName$)[a-zA-Z '])+$", ErrorMessage = "DepartName is required and must be properly formatted.")]
        public string DepartName { get; set; }

        [Required(ErrorMessage = "DepartNo is a Required field.")]
        public int DepartNo { get; set; }


        public DateTime LastModifiedAt { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; }
    }
}

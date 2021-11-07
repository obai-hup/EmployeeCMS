using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain
{
   public class Employer
    {
        public int Id { get; set; }

        [Required]
        [ MinLength(4)]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }

                    fullName += FirstName;
                }
                return fullName;
            }
        }

        [Required]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public virtual Department Department { get; set; }
    }
}

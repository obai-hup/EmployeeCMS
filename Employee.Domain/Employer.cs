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

        public string UserName { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

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

        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
}

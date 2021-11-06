using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Domain
{
    public class Department
    {
        public int ID { get; set; }

        public string DepartName { get; set; }

        public int DepartNo { get; set; }




        public DateTime CreatedAt { get; set; } 
        public string CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; } 
        public string LastModifiedBy { get; set; }

    }
}
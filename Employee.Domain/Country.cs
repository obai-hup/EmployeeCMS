using System.Collections;
using System.Collections.Generic;

namespace Employee.Domain
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Employer> Employer { get; set; }
    }
}
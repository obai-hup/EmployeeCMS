using Employee.Domain;
using Employee.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Web.Services
{
    public interface IEmployeeGUI
    {
        Task<IEnumerable<Employer>> GetEmployees();
        Task<Employer> GetEmployerById(int departId);
        Task<EditEmployerViewModel> GetEmploy(int departId);
        void AddEmployer(CreateEmployerViewModel createEmployer);
        void UpdateEmployer(Employer editEmployer);
        void DeleteEmployer(int id);
    }
}

using Employee.Domain;
using Employee.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Web.Services
{
    public interface IDepartmentGUI
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int departId);
        void AddDepartment(CreateDepartmentViewModel createDepartment);
        void UpdateDepartment(EditDepartmentViewModel editDepartment);
        void DeleteDepartment(int id);
    }
}

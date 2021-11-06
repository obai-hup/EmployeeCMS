using Employee.Domain;
using Employee.Domain.ViewModel;
using System.Collections.Generic;

namespace Employee.Services.Contract
{
    public interface IDepartmentRepository
    {
        Department Get(int id);
        IList<Department> GetAll();
       void Add(CreateDepartmentViewModel entity);
        void Update(int id ,EditDepartmentViewModel entity);
        void  Delete(int id);
        //Task<bool> Exists(int id);
        List<Department> Search(string term);

    }
}

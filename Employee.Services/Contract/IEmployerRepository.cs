using Employee.Domain;
using Employee.Domain.ViewModel;
using System.Collections.Generic;

namespace Employee.Services.Contract
{
    public interface IEmployerRepository
    {
        Employer Get(int id);
        IList<Employer> GetAll();
       void Add(CreateEmployerViewModel entity);
        void Update(int id , Employer entity);
        void  Delete(int id);
        //Task<bool> Exists(int id);
        List<Employer> Search(string term);

    }
}

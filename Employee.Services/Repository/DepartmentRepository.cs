using Employee.DAL;
using Employee.Domain;
using Employee.Domain.ViewModel;
using Employee.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.Services.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeCmsContext _context;
        public DepartmentRepository(EmployeeCmsContext context)
        {
            _context = context;
        }


        public void Add(CreateDepartmentViewModel entity)
        {
            var dep = new Department()
            {
                DepartName = entity.DepartName,
                DepartNo = entity.DepartNo,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy
            };
            _context.Departments.Add(dep);
            entity.CreatedAt = DateTime.Now;
             _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var employ = Get(id);
            _context.Departments.Remove(employ);
            _context.SaveChanges();
        }

        public Department Get(int id)
        {
            return _context.Departments.Where(i => i.ID == id).SingleOrDefault();

        }

        public IList<Department> GetAll()
        {
            return  _context.Departments.ToList();

        }

        public List<Department> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, EditDepartmentViewModel entity)
        {
            var depart = Get(id);
            depart.DepartName = entity.DepartName;
            depart.DepartNo = entity.DepartNo;
            depart.LastModifiedAt = entity.LastModifiedAt;
            depart.LastModifiedBy = entity.LastModifiedBy;

            _context.Departments.Update(depart);
             _context.SaveChanges();
        }
    }
}

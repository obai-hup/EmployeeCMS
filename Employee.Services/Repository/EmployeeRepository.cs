using Employee.DAL;
using Employee.Domain;
using Employee.Domain.ViewModel;
using Employee.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Employee.Services.Repository
{
    public class EmployeeRepository : IEmployerRepository
    {
        private readonly EmployeeCmsContext _context;
        //CountryApi _api = new CountryApi();

        public EmployeeRepository(EmployeeCmsContext context)
        {
            _context = context;
        }


     

        public void Add(CreateEmployerViewModel entity)
        {

            var employ = new Employer()
            {
                UserName = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                DepartmentID = entity.DepartID,
                CountryID = entity.CountryID

            };
            _context.Employers.Add(employ);
             _context.SaveChanges();
  
        }

        public void Delete(int id)
        {
            var employ =  Get(id);
            _context.Employers.Remove(employ);
            _context.SaveChanges();

        }

        //public async Task<bool> Exists(int id)
        //{
        //    Employer employer = await _context.Employers.SingleOrDefaultAsync(x => x.Id == id);
          

        //    return true;
        //}

        public Employer Get(int id)
        {
            return  _context.Employers.Include(d => d.Department).Include(c => c.Country).SingleOrDefault(x => x.Id == id);

        }

        public IList<Employer> GetAll()
        {
            return  _context.Employers.Include(D => D.Department).Include(C => C.Country).ToList();
        }

        public List<Employer> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void  Update(int id , Employer entity)
        {


           
            var employ = Get(id);
            employ.UserName = entity.UserName;
            employ.FirstName = entity.FirstName;
            employ.LastName = entity.LastName;
            employ.CountryID = entity.CountryID;
            employ.DepartmentID = entity.DepartmentID;
            employ.PhoneNumber = entity.PhoneNumber;

            if(employ != null)
            {
                _context.Employers.Update(employ);
                _context.SaveChanges();
            }
            
               
        }
    }
}

using AutoMapper;
using Employee.Domain;
using Employee.Domain.ViewModel;
using Employee.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployeeController(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;

        }

        // GET: api/Employer
        [HttpGet]

        public ActionResult<IEnumerable<Employer>> GetAll()
        {

            var AllEmployee = _employerRepository.GetAll();

            if(AllEmployee == null)
            {
                return NotFound();
            }

            return Ok(AllEmployee.ToList());

        }
        // GET: api/Employer/{Id}
        [HttpGet("{id}")]
        public ActionResult<Employer> EmployerById([FromRoute] int id)
        {

            var EmployerId = _employerRepository.Get(id);

            if (EmployerId != null)
            {
                return Ok(EmployerId);
            }
            else
            {
                return NotFound();
            }

        }



        //Post : api/Employer/
        [HttpPost]
        public ActionResult<Employer> CreateEmploy(CreateEmployerViewModel employerDto)
        {
            try
            {
                if (employerDto == null)
                {
                    return BadRequest(" يجب مل الفورم");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("خطأ");
                }
                //Map To UsersApp Model From source UsersCreateDto
                _employerRepository.Add(employerDto);

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500, "خطأ في النظام");
            }
        }

        //PUT : api/Employer / {id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployer(int id, Employer UpdateDTO)
        {
            var EmployFromRepo = _employerRepository.Get(id);
            if (EmployFromRepo == null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "There is something wrong");
            }

            _employerRepository.Update(EmployFromRepo.Id, UpdateDTO);

            return NoContent();
        }
        //Delete: api/Employer/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployer(int id)
        {
            var EmployFromRepo = _employerRepository.Get(id);
            if (EmployFromRepo == null)
            {
                return NotFound();
            }

            _employerRepository.Delete(EmployFromRepo.Id);

            return NoContent();
        }
    }
}

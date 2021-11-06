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
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
       

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: api/Department
        [HttpGet]

        public ActionResult<IEnumerable<Department>> GetAll()
        {

            var AllDepartment = _departmentRepository.GetAll();

            return Ok(AllDepartment.ToList());

        }
        // GET: api/department/{Id}
        [HttpGet("{id}")]

        public ActionResult<Department> DepartmentById([FromRoute] int id)
        {

            var departmentId = _departmentRepository.Get(id);

            if (departmentId != null)
            {
                return Ok(departmentId);
            }
            else
            {
                return NotFound();
            }

        }

        //Post : api/department/
        [HttpPost]
        public ActionResult CreateDepartment([FromBody]CreateDepartmentViewModel departmentDto)
        {
            try
            {
                if (departmentDto == null)
                {
                    return BadRequest("يجب ملء مل البيانات المطوبة");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("خطأ");
                }

             
                _departmentRepository.Add(departmentDto);

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500, "خطأ في النظام");
            }
        }

        //PUT : api/department / {id}
        [HttpPut("{id}")]

        public ActionResult UpdateDepartment(int id, EditDepartmentViewModel departmentDto)
        {
            if (id != departmentDto.ID)
                return BadRequest("رقم القسم لم يتطابق");


            var departFromRepo = _departmentRepository.Get(id);
            if (departFromRepo == null)
            {
                return NotFound(" لم يتم العثور علي القسم");
            }

            _departmentRepository.Update(departFromRepo.ID, departmentDto);

            return NoContent();
        }


        //Delete: api/Department/{id}
        [HttpDelete("{id}")]

        public ActionResult DeleteDepartment(int id)
        {
            var departFromRepo = _departmentRepository.Get(id);
            if (departFromRepo == null)
            {
                return NotFound();
            }

            _departmentRepository.Delete(departFromRepo.ID);

            return NoContent();
        }


    }
}

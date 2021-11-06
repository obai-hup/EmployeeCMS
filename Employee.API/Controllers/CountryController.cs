using Employee.DAL;
using Employee.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly EmployeeCmsContext _cmsContext;

        public CountryController(EmployeeCmsContext cmsContext)
        {
            _cmsContext = cmsContext;
        }

        // GET: api/Country
        [HttpGet]

        public ActionResult<IEnumerable<Country>> GetAll()
        {

            var AllCountry = _cmsContext.Countries.ToList();

            return Ok(AllCountry);

        }

        // GET: api/Country/{Id}
        [HttpGet("{id}", Name = "CountryById")]

        public ActionResult<Department> GetCountryById([FromRoute] int id)
        {

            var CountryId = _cmsContext.Countries.FirstOrDefault(x => x.CountryId == id);

            if (CountryId != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        //Post : api/Country/
        [HttpPost]

        public ActionResult<Country> CreateCategory(Country country)
        {
            try
            {
                if (country == null)
                {
                    return BadRequest("يجب ملء مل البيانات المطوبة");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("خطأ");
                }
                _cmsContext.Countries.Add(country);
                _cmsContext.SaveChanges();

                return CreatedAtRoute(nameof(GetCountryById), new { id = country.CountryId });
            }
            catch (Exception)
            {

                return StatusCode(500, "خطأ في النظام");
            }
        }

        //PUT : api/Country / {id}
        [HttpPut("{id}")]

        public ActionResult UpdateCountry(int id, Country country)
        {
            if (id != country.CountryId)
                return BadRequest("رقم البلد لم يتطابق");


            var CountryD = _cmsContext.Countries.Find(id);
            if (CountryD == null)
            {
                return NotFound(" لم يتم العثور علي البلد");
            }

            //_mapper.Map(UpdateDTO, CatFromRepo);
            _cmsContext.Update(CountryD);
            _cmsContext.SaveChanges();

            return NoContent();
        }


        //Delete: api/Country/{id}
        [HttpDelete("{id}")]

        public ActionResult DeleteCountry(int id)
        {
            var CountryRepo = _cmsContext.Countries.Find(id);
            if (CountryRepo == null)
            {
                return NotFound();
            }

            _cmsContext.Remove(CountryRepo);
            _cmsContext.SaveChanges();

            return NoContent();
        }
    }
}

using Employee.Domain;
using Employee.Domain.ViewModel;
using Employee.Web.Helper;
using Employee.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employee.Web.Controllers
{
    public class EmployersController : Controller
    {
        HelperApi _api = new HelperApi();

        IDepartmentGUI _DepartmentRepository;
        IEmployeeGUI _EmployeeRepository;
        public EmployersController(IDepartmentGUI departmentRepository, IEmployeeGUI EmployeeRepository)
        {
            _DepartmentRepository = departmentRepository;
            _EmployeeRepository = EmployeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Employ = await _EmployeeRepository.GetEmployees();

            if (Employ == null)
            {
                ViewBag.Message = "There No Department Exists";
            }
            return View(Employ.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var Employ = await _EmployeeRepository.GetEmployerById(id);
            return View(Employ);
        }

        public async Task<IActionResult> Create()
        {
            // Get Department
            var depart = await _DepartmentRepository.GetDepartments();
            ViewBag.department = new SelectList(depart, "ID", "DepartName");

            // Get Country

            List<Country> countrie = new List<Country>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("https://localhost:44390/api/Country");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                countrie = JsonConvert.DeserializeObject<List<Country>>(result);
            }

            //ViewBag.Country = countrie;
            ViewBag.Country = new SelectList(countrie.OrderBy(x => x.Name), "CountryId", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Server Error , Please Contact admin");
            }
            _EmployeeRepository.AddEmployer(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var Emplooy = _EmployeeRepository.GetEmployerById(id);

            if (Emplooy != null)
            {
                _EmployeeRepository.DeleteEmployer(id);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            // Get Department
            var depart = await _DepartmentRepository.GetDepartments();
            ViewBag.department = new SelectList(depart, "ID", "DepartName");

            // Get Country

            List<Country> countrie = new List<Country>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("https://localhost:44390/api/Country");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                countrie = JsonConvert.DeserializeObject<List<Country>>(result);
            }

            //ViewBag.Country = countrie;
            ViewBag.Country = new SelectList(countrie.OrderBy(x => x.Name), "CountryId", "Name");

            //employ
            var Employ = new Employer();


            HttpResponseMessage responseMessage = await client.GetAsync($"api/Employee/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                Employ = JsonConvert.DeserializeObject<Employer>(result);
            }


            if (Employ == null)
            {
                return NotFound();
            }

            ViewBag.department = new SelectList(depart, "ID", "DepartName");

            return View(Employ);
        }

        [HttpPost]
        public IActionResult Edit(Employer viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Server Error , Please Contact admin");
            }
            _EmployeeRepository.UpdateEmployer(viewModel);
            return RedirectToAction("Index");
        }
    }
}

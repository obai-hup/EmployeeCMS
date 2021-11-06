using Employee.Domain;
using Employee.Domain.ViewModel;
using Employee.Web.Helper;
using Employee.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employee.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        HelperApi _api = new HelperApi();

        IDepartmentGUI _DepartmentRepository;

        public DepartmentsController(IDepartmentGUI departmentRepository)
        {
            _DepartmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Depart = await _DepartmentRepository.GetDepartments();

            if(Depart == null)
            {
                ViewBag.Message = "There No Department Exists";
            }
            return View(Depart.ToList());
        }

        public async Task<IActionResult> Details(int id)
        {
            var depart = await _DepartmentRepository.GetDepartmentById(id);
            return View(depart);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Server Error , Please Contact admin");
            }
            _DepartmentRepository.AddDepartment(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var derpart = _DepartmentRepository.GetDepartmentById(id);

            if(derpart != null)
            {
                _DepartmentRepository.DeleteDepartment(id);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var departments = new EditDepartmentViewModel();

            HttpClient client = _api.Initial();

            HttpResponseMessage responseMessage = await client.GetAsync($"Department/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                departments = JsonConvert.DeserializeObject<EditDepartmentViewModel>(result);
            }

            if (departments == null)
            {
                return NotFound();
            }
            return View(departments);
        }

        [HttpPost]
        public IActionResult Edit(EditDepartmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Server Error , Please Contact admin");
            }
             _DepartmentRepository.UpdateDepartment(viewModel);
            return RedirectToAction("Index");
        }
    }
}

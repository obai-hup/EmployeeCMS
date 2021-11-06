using Employee.Domain;
using Employee.Domain.ViewModel;
using Employee.Web.Helper;
using Employee.Web.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Employee.Web.Repositories
{
    public class DepartmentRepositoryGUI : IDepartmentGUI
    {

        HelperApi _api = new HelperApi();

        public void AddDepartment(CreateDepartmentViewModel viewModel)
        {
            HttpClient client = _api.Initial();

            //HTTP POST
            var PostTask = client.PostAsJsonAsync<CreateDepartmentViewModel>("Department", viewModel);
            PostTask.Wait();

            var result = PostTask.Result;

           
        }

        public async void DeleteDepartment(int id)
        {
            var depart = new Department();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"Department/{id}");


        }

        public async Task<Department> GetDepartmentById(int departId)
        {
            var departments = new Department();

            HttpClient client = _api.Initial();

            HttpResponseMessage responseMessage = await client.GetAsync($"Department/{departId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                departments = JsonConvert.DeserializeObject<Department>(result);
            }

            return departments;

        }

        public async  Task<IEnumerable<Department>> GetDepartments()
        {
            IEnumerable<Department> departments = new List<Department>();

            HttpClient client = _api.Initial();

            HttpResponseMessage responseMessage = await client.GetAsync("Department");

            if(responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                departments = JsonConvert.DeserializeObject<List<Department>>(result);
            }

            return departments;
        }

        public async void UpdateDepartment(EditDepartmentViewModel editDepartment)
        {

            HttpClient client = _api.Initial();

            HttpResponseMessage responseMessage =  client.PutAsJsonAsync<EditDepartmentViewModel>($"Department/{editDepartment.ID}", editDepartment).Result;
           
            
        }
    }
}

using Employee.Domain;
using Employee.Domain.ViewModel;
using Employee.Web.Helper;
using Employee.Web.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Employee.Web.Repositories
{
    public class EmployerRepositoryGUI : IEmployeeGUI
    {
        HelperApi _api = new HelperApi();


        public void AddEmployer(CreateEmployerViewModel createEmployer)
        {

            HttpClient client = _api.Initial();

            //HTTP POST
            var PostTask = client.PostAsJsonAsync<CreateEmployerViewModel>("api/Employee", createEmployer);
            PostTask.Wait();

            var result = PostTask.Result;
        }

        public async void DeleteEmployer(int id)
        {
            var depart = new Employer();
            HttpClient client = _api.Initial();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"api/Employee/{id}");
        }

        public async Task<EditEmployerViewModel> GetEmploy(int departId)
        {
            var employer = new EditEmployerViewModel();

            HttpClient client = _api.Initial();

            HttpResponseMessage responseMessage = await client.GetAsync($"api/Employee/{departId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                employer = JsonConvert.DeserializeObject<EditEmployerViewModel>(result);
            }

            return employer;
        }

        public async Task<IEnumerable<Employer>> GetEmployees()
        {
            IEnumerable<Employer> employer = new List<Employer>();

            HttpClient client = _api.Initial();

            HttpResponseMessage responseMessage = await client.GetAsync("api/Employee");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                employer = JsonConvert.DeserializeObject<List<Employer>>(result);
            }

            return employer;
        }

        public async Task<Employer> GetEmployerById(int departId)
        {
            var employer = new Employer();

            HttpClient client = _api.Initial();

            HttpResponseMessage responseMessage = await client.GetAsync($"api/Employee/{departId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                employer = JsonConvert.DeserializeObject<Employer>(result);
            }

            return employer;
        }

        public void UpdateEmployer(Employer editEmployer)
        {
            HttpClient client = _api.Initial();

            HttpResponseMessage responseMessage = client.PutAsJsonAsync<Employer>($"api/Employee/{editEmployer.Id}", editEmployer).Result;
        }
    }
}

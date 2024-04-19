using DevFreela.App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace DevFreela.App.Controllers
{
    public class ProjectController : Controller
    {
        private readonly string ANDPOINT = "http://localhost:29851/api/projects";
        private readonly HttpClient httpClien = null;

        public ProjectController()
        {
            httpClien = new HttpClient();
            httpClien.BaseAddress = new Uri(ANDPOINT);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<ProjectViewModel> projects= null;

                HttpResponseMessage response = await httpClien.GetAsync(ANDPOINT);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    projects = JsonConvert.DeserializeObject<List<ProjectViewModel>>(content);

                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");
                }

                return View(projects);

            }catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
            return View();
        }
    }
}

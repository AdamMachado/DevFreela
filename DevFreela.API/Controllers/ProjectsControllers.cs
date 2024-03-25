using DevFreela.API.Model;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsControllers : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsControllers(IProjectService projectService)
        {
            _projectService = projectService;

        }

        //api/project?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //Buscar todos ou filtrar
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        //api/project/599
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca o projeto
            var project = _projectService.GetById(id);

            if(project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        
        
        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if(inputModel.Title.Length > 50)
            {
                return BadRequest();

            }
            var id = _projectService.Create(inputModel);

            //Cadastro do projeto
            return CreatedAtAction(nameof(GetById), new { id = id },inputModel);

        }
        //api/project/3 Put
        [HttpPut("{id}")]
        public IActionResult Put(int Id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectService.Update(inputModel);
            //Atualizar o projeto
            return NoContent();
        }

        //api/project/59 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Buscar se não existir retornar not found
            _projectService.Delete(id);
            //Remover
            return NoContent();
        }

        //api/project/59/comment
        [HttpPost("{id}/comments")]
        public IActionResult PostComments(int id,[FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);
            return NoContent();
        }


        //api/project/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        //api/project/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }

    }
}

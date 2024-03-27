using DevFreela.API.Model;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsControllers : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsControllers(IProjectService projectService, IMediator mediatR)
        {
            _projectService = projectService;
            _mediator = mediatR;

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
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if(command.Title.Length > 50)
            {
                return BadRequest();

            }
            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);
            //Cadastro do projeto
            return CreatedAtAction(nameof(GetById), new { id = id }, command);

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

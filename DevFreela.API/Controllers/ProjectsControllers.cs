using DevFreela.API.Model;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartedProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsControllers : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProjectsControllers(IMediator mediatR)
        {

            _mediator = mediatR;

        }

        //api/project?query=net core
        [HttpGet]
        [Authorize(Roles="client,freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            //Buscar todos ou filtrar
            var getAllProjectsQuery = new GetAllProjectsQuery(query);
            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        //api/project/599
        [HttpGet("{id}")]
        [Authorize(Roles = "client,freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            //Busca o projeto
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }
        
        
        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {



            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);
            //Cadastro do projeto
            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }
        //api/project/3 Put
        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int Id, [FromBody] UpdateProjectCommand inputModel)
        {
            if(inputModel.Description.Length > 200)
            {
                return BadRequest();
            }
            await _mediator.Send(inputModel);

            return NoContent();
        }

        //api/project/59 

        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            //Buscar se não existir retornar not found
            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command);
            //Remover
            return NoContent();
        }

        //api/project/59/comment
        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client,freelancer")]
        public async Task<IActionResult> PostComments(int id,[FromBody] CreateProjectCommand inputModel)
        {
            await _mediator.Send(inputModel);
          
            return NoContent();
        }


        //api/project/1/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        //api/project/1/finish
        [HttpPut("{id}/finish")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

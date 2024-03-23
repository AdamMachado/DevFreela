using DevFreela.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsControllers : ControllerBase
    {
        //api/project?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            //Buscar todos ou filtrar

            return Ok();
        }

        //api/project/599
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca o projeto

            return Ok();
        }
        
        
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if(createProject.Title.Length > 50)
            {
                return BadRequest();

            }

            //Cadastro do projeto
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);

        }
        //api/project/3 Put
        [HttpPut("{id}")]
        public IActionResult Put(int Id, [FromBody] UpdateProjectModel updateProject)
        {
            if(updateProject.Description.Length > 200)
            {
                return BadRequest();
            }


            //Atualizar o projeto
            return NoContent();
        }

        //api/project/59 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Buscar se não existir retornar not found

            //Remover
            return NoContent();
        }

        //api/project/59/comment

        [HttpPost("{id}/comments")]
        public IActionResult PostComments(int id,[FromBody] CreateCommentModel createCommentModel)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        //api/project/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }

    }
}

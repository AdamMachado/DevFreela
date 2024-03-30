using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DevFreela.API.Filter
{
    public class ValidateFilter : IActionFilter

    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var message = context.ModelState
                   
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(p => p.ErrorMessage)
                    .ToList();
                context.Result = new BadRequestObjectResult(message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using WebApp.Exceptions;

namespace NetMicroservice.Attributes;

public class ValidationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errorsInModelState = context.ModelState.First(x => x.Value != null && x.Value.Errors.Count > 0);
            throw new InvalidParamsException(errorsInModelState.Value!.Errors.First().ErrorMessage);
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    //public class MyAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    //{
    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class MyResourceFilterAttribute : Attribute, IResourceFilter
    //{
    //    public void OnResourceExecuting(ResourceExecutingContext context)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void OnResourceExecuted(ResourceExecutedContext context)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class MyExceptionFilterAttribute : Attribute, IExceptionFilter
    //{
    //    public void OnException(ExceptionContext context)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class MyFilterAttribute : Attribute, IAsyncActionFilter, IAsyncResultFilter
    //{
    //    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    [AttributeUsage(AttributeTargets.Method)]
    public class MyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}

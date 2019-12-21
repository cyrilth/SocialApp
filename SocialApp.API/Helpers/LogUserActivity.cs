using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialApp.API.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SocialApp.API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var repo = resultContext.HttpContext.RequestServices.GetService<ISocialRepository>();

            var user = await repo.GetUser(userId);
            
            user.LastActive = DateTime.Now;

            await repo.SaveAll();
        }
    }
}
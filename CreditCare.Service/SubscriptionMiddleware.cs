using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CreditCare.Domain;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
namespace CreditCare.Service
{
    public class SubscriptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;

        public SubscriptionMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));  // Ensure next is properly injected
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                if (context.User.Identity.IsAuthenticated)
                {
                    var user = await userManager.GetUserAsync(context.User);

                    if (user != null)
                    {
                        bool hasAccess = user.IsSubscribed || (user.TrialEndDate >= DateTime.UtcNow);

                        if (!hasAccess)
                        {
                            context.Response.Redirect("/Account/Subscribe");
                            return;
                        }
                    }
                }

                await _next(context);  // Call the next middleware in the pipeline
            }
        }
    }

}


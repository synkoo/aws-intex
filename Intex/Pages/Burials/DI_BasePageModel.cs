using System.Security.AccessControl;
using Intex.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Intex.Pages.Contacts
{
    public class DI_BasePageModel : PageModel
    {
        protected ApplicationDbContext Context { get; }

        //Access the authorization handlers
        protected IAuthorizationService AuthorizationService { get; }

        //Add UserManager service
        protected UserManager<IdentityUser> UserManager { get; }

        protected IConfiguration Configuration { get; }

        public DI_BasePageModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration): base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
            Configuration = configuration;
        }
    }
}
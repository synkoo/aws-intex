using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Intex.Data;
using Intex.Models;
using Intex.Pages.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Intex.Authorization;
using Microsoft.Extensions.Configuration;


namespace Intex.Pages.Burials
{
    [Authorize]
    public class DeleteModel : DI_BasePageModel
    {
        public DeleteModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
            : base(context, authorizationService, userManager, configuration)
        {
        }

        [BindProperty]
        public Burial Burial { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Burial = await Context.Burial.FirstOrDefaultAsync(
                                                 m => m.BurialId == id);

            if (Burial == null)
            {
                return NotFound();
            }

            //Use the authorization handler to verify the user has delete permission
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Burial,
                                                     BurialOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var burial = await Context
                .Burial.AsNoTracking()
                .FirstOrDefaultAsync(m => m.BurialId == id);

            if (burial == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, burial,
                                                     BurialOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Burial.Remove(burial);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Discoveries");
        }
    }
}

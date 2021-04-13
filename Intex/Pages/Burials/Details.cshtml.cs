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
    public class DetailsModel : DI_BasePageModel
    {
        public DetailsModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
            : base(context, authorizationService, userManager, configuration)
        {
        }

        public Burial Burial { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Burial = await Context.Burial.FirstOrDefaultAsync(m => m.BurialId == id);

            if (Burial == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.BurialManagersRole) ||
                               User.IsInRole(Constants.BurialAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Burial.OwnerId
                && Burial.Status != BurialStatus.Approved)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, BurialStatus status)
        {
            var burial = await Context.Burial.FirstOrDefaultAsync(
                                                      m => m.BurialId == id);

            if (burial == null)
            {
                return NotFound();
            }

            var burialOperation = (status == BurialStatus.Approved)
                                                       ? BurialOperations.Approve
                                                       : BurialOperations.Reject;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, burial,
                                        burialOperation);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            burial.Status = status;
            Context.Burial.Update(burial);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Discoveries");
        }
    }
}

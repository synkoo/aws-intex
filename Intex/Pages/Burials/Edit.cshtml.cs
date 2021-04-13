using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class EditModel : DI_BasePageModel
    {
        public EditModel(
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

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                      User, Burial,
                                                      BurialOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch Contact from DB to get OwnerID.
            var burial = await Context
                .Burial.AsNoTracking()
                .FirstOrDefaultAsync(m => m.BurialId == id);

            if (burial == null)
            {
                return NotFound();
            }

            //Add authorization handler to verify the user owns the burial
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, burial,
                                                     BurialOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Burial.OwnerId = burial.OwnerId;

            Context.Attach(Burial).State = EntityState.Modified;

            if (Burial.Status == BurialStatus.Approved)
            {
                // If the contact is updated after approval, 
                // and the user cannot approve,
                // set the status back to submitted so the update can be
                // checked and approved.
                var canApprove = await AuthorizationService.AuthorizeAsync(User,
                                        Burial,
                                        BurialOperations.Approve);

                if (!canApprove.Succeeded)
                {
                    Burial.Status = BurialStatus.Submitted;
                }
            }

            await Context.SaveChangesAsync();

            return RedirectToPage("./Discoveries");
        }
    }
}

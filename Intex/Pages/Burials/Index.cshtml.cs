using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Intex.Data;
using Intex.Models;
using Microsoft.AspNetCore.Authorization;
using Intex.Pages.Contacts;
using Microsoft.AspNetCore.Identity;
using Intex.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace Intex.Pages.Burials
{
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
            : base(context, authorizationService, userManager, configuration)
        {
        }


        //For sorting and filtering
        public string NameSort { get; set; }
        public string LengthSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string Sex { get; set; }
        public string HairColor { get; set; }
        public string YearFound { get; set; }
        public string HeadDirection { get; set; }
        public string ArtifactFound { get; set; }

        public PaginatedList<Burial> Burial { get; set; }

        //Only approved contacts are shown to general users
        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex, string Sex,
            string HairColor, string YearFound, string HeadDirection, string ArtifactFound)
        {
            var burials = from c in Context.Burial
                           select c;

            var isAuthorized = User.IsInRole(Constants.BurialManagersRole) ||
                               User.IsInRole(Constants.BurialAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            CurrentFilter = searchString;

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            LengthSort = sortOrder == "Length" ? "length_desc" : "Length";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner.

            if (!User.Identity.IsAuthenticated)
            {
                burials = burials.Where(c => c.Status == BurialStatus.Approved);
            }

            if (!isAuthorized)
            {
                burials = burials.Where(c => c.Status == BurialStatus.Approved
                                            || c.OwnerId == currentUserId);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                burials = burials.Where(b => b.BurialId.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(Sex))
            {
                burials = burials.Where(b => b.GenderGe.Equals(Sex));
            }

            if (!String.IsNullOrEmpty(HairColor))
            {
                burials = burials.Where(b => b.HairColor.Equals(HairColor));
            }

            if (!String.IsNullOrEmpty(YearFound))
            {
                burials = burials.Where(b => b.YearFound.Equals(YearFound));
            }

            if (!String.IsNullOrEmpty(HeadDirection))
            {
                burials = burials.Where(b => b.HeadDirection.Equals(HeadDirection));
            }

            if (!String.IsNullOrEmpty(ArtifactFound))
            {
                burials = burials.Where(b => b.ArtifactFound.Equals(ArtifactFound));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    burials = burials.OrderByDescending(b => b.BurialId);
                    break;
                case "Length":
                    burials = burials.OrderBy(b => b.LengthOfRemains);
                    break;
                case "length_desc":
                    burials = burials.OrderByDescending(s => s.LengthOfRemains);
                    break;
                default:
                    burials = burials.OrderBy(b => b.BurialId);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 11);

            Burial = await PaginatedList<Burial>.CreateAsync(burials.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
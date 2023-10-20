using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdPlatFormApp.Pages.AdminPage
{
    public class DetailProviderModel : PageModel
    {
        private readonly IProviderRepository _providerRepository;

        public DetailProviderModel(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public Provider providerModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            providerModel = await _providerRepository.GetProviderById(id);

            if (providerModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

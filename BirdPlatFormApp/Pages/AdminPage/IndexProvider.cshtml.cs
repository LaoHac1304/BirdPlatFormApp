using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdPlatFormApp.Pages.AdminPage
{
    public class IndexProviderModel : PageModel
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IndexProviderModel(IProviderRepository providerRepository, IHttpContextAccessor httpContextAccessor)
        {
            _providerRepository = providerRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Provider> Providers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Providers = _providerRepository.GetAll();
            return Page();
        }
    }
}

using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BirdPlatFormApp.Pages.ProviderPages
{
    public class IndexBirdServiceModel : PageModel
    {
        private readonly IBirdServiceRepository BirdServideRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IndexBirdServiceModel(IBirdServiceRepository birdServiceRepository, IHttpContextAccessor httpContextAccessor)
        {
            BirdServideRepository = birdServiceRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<BirdService> birdServices { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            birdServices = BirdServideRepository.GetAll();
            return Page();
        }
    }
}

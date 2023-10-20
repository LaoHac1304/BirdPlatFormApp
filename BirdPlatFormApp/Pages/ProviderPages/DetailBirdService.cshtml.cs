using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdPlatFormApp.Pages.ProviderPages
{
    public class DetailBirdServiceModel : PageModel
    {
        private readonly IBirdServiceRepository birdServiceRepository;

        public DetailBirdServiceModel(IBirdServiceRepository birdServiceRepository)
        {
            this.birdServiceRepository = birdServiceRepository;
        }

        public BirdService birdServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            birdServiceModel = await birdServiceRepository.GetBirdServiceById(id);

            if (birdServiceModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

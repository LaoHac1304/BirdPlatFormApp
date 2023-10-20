using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BirdPlatFormApp.Pages.ProviderPages
{
    public class DeleteBirdServiceModel : PageModel
    {
        private readonly IBirdServiceRepository _birdServiceRepository;

        public DeleteBirdServiceModel(IBirdServiceRepository birdServiceRepository)
        {
            _birdServiceRepository = birdServiceRepository;
        }

        [BindProperty]
        public BirdService birdServiceModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            birdServiceModel = await _birdServiceRepository.GetBirdServiceById(id);

            if (birdServiceModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            birdServiceModel = await _birdServiceRepository.GetBirdServiceById(id);

            if (birdServiceModel != null)
            {
                await _birdServiceRepository.DeleteAsync(birdServiceModel);
            }

            return RedirectToPage("./BirdServiceIndex");
        }
    }
}

using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BirdPlatFormApp.Pages.ProviderPages
{
    public class UpdateBirdServiceModel : PageModel
    {
        private readonly IBirdServiceRepository birdServiceRepository;
        private readonly IProviderRepository _providerRepository;
        public UpdateBirdServiceModel(IBirdServiceRepository birdServiceRepository, IProviderRepository providerRepository)
        {
            this.birdServiceRepository = birdServiceRepository;
            _providerRepository = providerRepository;
        }

        [BindProperty]
        public BirdService birdServiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            birdServiceModel = await birdServiceRepository.GetBirdServiceById(id);
            if (birdServiceModel == null)
            {
                return NotFound();
            }
            ViewData["ProviderId"] = new SelectList(_providerRepository.GetAll(), "CategoryId", "ProviderName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                birdServiceRepository.UpdateAsync(birdServiceModel);
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw new Exception(ex.Message);

            }

            return RedirectToPage("./BirdServiceIndex");
        }
    }
}

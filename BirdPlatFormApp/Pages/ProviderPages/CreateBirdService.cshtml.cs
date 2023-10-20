using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirdPlatFormApp.Pages.ProviderPages
{
    public class CreateBirdServiceModel : PageModel
    {
        private readonly IBirdServiceRepository _birdServiceRepository;
        private readonly IProviderRepository _providerRepository;

        public CreateBirdServiceModel(IBirdServiceRepository birdServiceRepository, IProviderRepository providerRepository)
        {
            _birdServiceRepository = birdServiceRepository;
            _providerRepository = providerRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["ProviderId"] = new SelectList(_providerRepository.GetAll(), "ProviderId", "ProviderName");
            return Page();
        }

        [BindProperty]
        public  BIrdServiceModel birdServiceModel { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            BirdService birdService = new BirdService
            {
                ProductName = birdServiceModel.ProductName,
                ProductPrice = birdServiceModel.ProductPrice,
                Description = birdServiceModel.Description,
                IsActive = birdServiceModel.IsActive,
                TypeId = birdServiceModel.TypeId,
                ProviderId = birdServiceModel.ProviderId,
            };
            await _birdServiceRepository.CreateAsync(birdService);
            return RedirectToPage("./BirdServiceIndex");
        }
    }
}

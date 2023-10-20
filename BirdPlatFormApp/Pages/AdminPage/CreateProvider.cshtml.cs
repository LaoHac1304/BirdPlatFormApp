using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirdPlatFormApp.Pages.AdminPage
{
    public class CreateProviderModel : PageModel
    {
        private readonly IProviderRepository _providerRepository;

        public CreateProviderModel(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Provider birdServiceModel { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Provider birdService = new Provider
            {
                ProviderName = birdServiceModel.ProviderName,
                Password = birdServiceModel.Password,
                Address = birdServiceModel.Address,
                Birthday = birdServiceModel.Birthday,
                PhoneNumber = birdServiceModel.PhoneNumber,
                IsActive = birdServiceModel.IsActive,s
                RoleId = birdServiceModel.RoleId,
            };
            await _providerRepository.CreateAsync(birdService);
            return RedirectToPage("./ProviderIndex");
        }
    }
}

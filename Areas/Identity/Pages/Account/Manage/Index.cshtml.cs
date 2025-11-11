using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Opiskelijaportaali.Models;


namespace Opiskelijaportaali.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Profile> _userManager;
        private readonly SignInManager<Profile> _signInManager;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
            UserManager<Profile> userManager,
            SignInManager<Profile> signInManager,
            ILogger<IndexModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "First name")]
            public string FName { get; set; }

            [Display(Name = "Last name")]
            public string LName { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Birth date")]
            [DataType(DataType.Date)]
            public DateTime? Bdate { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }
        }

        private async Task LoadAsync(Profile user)
        {
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Input = new InputModel
            {
                FName = user.FName,
                LName = user.LName,
                Email = user.Email,
                PhoneNumber = user.Phone,
                Bdate = user.Bdate
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("Unable to load user.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("Unable to load user.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            // Päivitä käyttäjän perustiedot
            user.FName = Input.FName;
            user.LName = Input.LName;
            user.Email = Input.Email;
            user.Bdate = Input.Bdate;
            await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Error saving changes.";
                return RedirectToPage();
            }

            // Vaihda salasana, jos uusi annettu
            if (!string.IsNullOrEmpty(Input.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetResult = await _userManager.ResetPasswordAsync(user, token, Input.NewPassword);

                if (!resetResult.Succeeded)
                {
                    StatusMessage = "Error changing password.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated!";
            return RedirectToPage();
        }
    }
}
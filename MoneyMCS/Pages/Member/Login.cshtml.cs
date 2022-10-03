using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoneyMCS.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace MoneyMCS.Pages.Member
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {

        public LoginModel(UserManager<MemberUser> userManager, SignInManager<MemberUser> signInManager, ILogger<LoginModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }

        private readonly UserManager<MemberUser> _userManager;
        private readonly SignInManager<MemberUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

        }

        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }

                ModelState.AddModelError(String.Empty, "Invalid username or password");
            }


            return Page();
        }
    }
}
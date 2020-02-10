using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgnAppTestSQL.Data;
using IgnAppTestSQL.Pages.Account.InputModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IgnAppTestSQL.Pages.Account
{
    public class LoginModel : PageModel
    {
        private IgniteContext _context;
        private readonly SignInManager<IgniteUser> _signInManager;
        private readonly UserManager<IgniteUser> _userManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IgniteRole> _roleManager;

        public LoginModel(IgniteContext context, SignInManager<IgniteUser> signInManager, UserManager<IgniteUser> userManager, ILogger<LoginModel> logger, IEmailSender emailSender, RoleManager<IgniteRole> roleManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGet(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = _context.IgniteUsers.FirstOrDefault(i => i.Email == Input.Email);
                //var user = await _userManager.FindByEmailAsync(Input.Email);

                if (user != null && !user.EmailConfirmed)
                {
                    return RedirectToPage("Confirm/VerifyEmail", new { id = Input.Email });
                }

                var result =
                    await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, true);

                //try
                //{
                //    if (!result.Succeeded)
                //    {
                //        _logger.LogInformation("User Logged In");
                //    }
                //}
                //catch (Exception e)
                //{
                //    if (result.Succeeded)
                //    {
                //        Console.WriteLine(e);
                //        throw;
                //    }
                    
                //}

                if (result.Succeeded)
                {
                    _logger.LogInformation("User Logged In");
                    var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
                    var identity = userPrincipal.Identity;
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    _logger.LogInformation("Requires Two Factor");
                    ViewData.Add("RTF", "Need Two Factor");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogInformation("User acc locked out");
                    ViewData.Add("LO", "Account Locked Out");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            return Page();
        }
    }
}
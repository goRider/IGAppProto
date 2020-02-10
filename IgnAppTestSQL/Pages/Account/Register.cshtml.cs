using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using IgnAppTestSQL.Data;
using IgnAppTestSQL.Data.Utility;
using IgnAppTestSQL.Pages.Account.InputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IgnAppTestSQL.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IgniteUser> _signInManager;
        private readonly UserManager<IgniteUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IgniteRole> _roleManager;
        private readonly IgniteContext _context;

        public RegisterModel(SignInManager<IgniteUser> signInManager, UserManager<IgniteUser> userManager, ILogger<RegisterModel> logger, IEmailSender emailSender, RoleManager<IgniteRole> roleManager, IgniteContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
        }

        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("css~/");

            if (ModelState.IsValid)
            {
                var user = new IgniteUser
                {
                    UserName = Input.UserName,
                    NormalizedUserName = Input.UserName,
                    Email = Input.Email,
                    IgniteEmail = Input.Email,
                    NormalizedEmail = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    IsInternalUser = true,
                    HiredDate = DateTime.Now
                };

                if (!Input.IsAdmin)
                {
                    user.EmailConfirmed = true;
                }

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (await _roleManager.RoleExistsAsync(UserRole.AdminUser))
                    {
                        await _roleManager.CreateAsync(new IgniteRole(UserRole.AdminUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(UserRole.HR))
                    {
                        await _roleManager.CreateAsync(new IgniteRole(UserRole.HR));
                    }
                    if (!await _roleManager.RoleExistsAsync(UserRole.ManagerUser))
                    {
                        await _roleManager.CreateAsync(new IgniteRole(UserRole.ManagerUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(UserRole.RegEmp))
                    {
                        await _roleManager.CreateAsync(new IgniteRole(UserRole.RegEmp));
                    }

                    if (Input.IsAdmin)
                    {
                        await _userManager.AddToRoleAsync(user, UserRole.AdminUser);
                    }

                    await _userManager.AddToRoleAsync(user, UserRole.AdminUser);
                    // _logger.LogInformation("User created a new");

                    _logger.LogInformation("User createed a new account with password");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page("/Confirm/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Please confirm email", $"Please confirm your account by <a href='{ HtmlEncoder.Default.Encode(callbackUrl) }'>Click Here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //_context.IgniteUserApplications.Add();

                    await _context.SaveChangesAsync();
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
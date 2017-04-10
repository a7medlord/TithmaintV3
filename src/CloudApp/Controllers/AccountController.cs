using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using CloudApp.Models;
using CloudApp.Models.AccountViewModels;
using CloudApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudApp.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private ApplicationDbContext _context;
        private IHostingEnvironment _env;
        public static string userName;
        public static string picId;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory , ApplicationDbContext context , RoleManager<IdentityRole> roleManager , IHostingEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _context = context;
            _roleManager = roleManager;
            _env = env;
            
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
          
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
               
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    var userdata = _context.Users.SingleOrDefault(user => user.UserName == model.UserName);
                   userName = userdata.EmployName;
                    picId = userdata.ProfilePic + ".jpg";
                    return RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "خطأ في تسجيل الدخول الرجاء تاكد من صحة المعلومات المدخلة");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult Addroles()
        {

            return View("Addroles");
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Addroles(IdentityRole role)
        {
           await _roleManager.CreateAsync(role);
            return RedirectToAction("Addroles");
        }


        //
        // GET: /Account/Register
        [HttpGet]
        
        public async Task<ViewResult> Register()
        {
            ViewData["roles"] = await _context.Roles.ToListAsync();
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind]RegisterViewModel model, string[] rolesids)
        {
         
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName, Email = model.Email , EmployName = model.EmployName , MemberId = model.MemberId 
                    , PhoneNumber = model.PhoneNumber , IdentityId = model.IdentityId,SigImage = model.SigPic ,
                    InterPercentage = model.InterPercentage,
                    MuthminPercentage = model.MuthminPercentage,
                    AduitPercentage = model.AduitPercentage,
                    AproverPercentage = model.AproverPercentage,
                    SupervisionPercentage = model.SupervisionPercentage,
                };

              await SaveFiles(user);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ApplicationUser users = _context.Users.SingleOrDefault(applicationUser => applicationUser.UserName == model.UserName);
                    await _userManager.AddToRolesAsync(users, rolesids);
                
                    return View("UserCreatedSecuss");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> EditRegister(string id)
        {
            var model = _context.Users.SingleOrDefault(us => us.Id == id);
          
                RegisterViewModel usermodel = new RegisterViewModel()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmployName = model.EmployName,
                    MemberId = model.MemberId
                    ,
                    PhoneNumber = model.PhoneNumber,
                    IdentityId = model.IdentityId ,
                    Id = model.Id ,
                    IdenetityPic = model.IdenetityPic ,
                    ProfilePic = model.ProfilePic,
                    MemberPhotoId = model.MemberPhotoId ,
                    SigPic = model.SigImage,
                    InterPercentage = model.InterPercentage,
                    MuthminPercentage = model.MuthminPercentage,
                    AduitPercentage = model.AduitPercentage,
                    AproverPercentage = model.AproverPercentage,
                    SupervisionPercentage = model.SupervisionPercentage
                };
            ViewData["roles"] = await _context.Roles.ToListAsync();
            ViewData["userRoles"] = await _userManager.GetRolesAsync(model);
            return View("EditReqisterUsers" , usermodel);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditRegister([Bind]RegisterViewModel model , string[] rolesids)
        {
            var useris = _context.Users.SingleOrDefault(user => user.Id == model.Id);
            
            useris.UserName = model.UserName;
            useris.Email = model.Email;
            useris.EmployName = model.EmployName;
            useris.MemberId = model.MemberId;

            useris.PhoneNumber = model.PhoneNumber;
            useris.IdentityId = model.IdentityId;
            useris.InterPercentage = model.InterPercentage;
            useris.MuthminPercentage = model.MuthminPercentage;
            useris.AduitPercentage = model.AduitPercentage;
            useris.AproverPercentage = model.AproverPercentage;
            useris.SupervisionPercentage = model.SupervisionPercentage;
         
            
            if (ModelState.IsValid)
            {
                 _context.Update(useris);
               _context.RemoveRange(_context.UserRoles.Where(role => role.UserId == useris.Id));
               await SaveFiles(useris);
                if (_context.SaveChanges() >0)
                {
                    for (int i = 0; i < rolesids.Length; i++)
                    {
                        await _userManager.AddToRolesAsync(useris, rolesids);
                    }
                    return RedirectToAction("RegisterIndex" );
                }
            }
            ViewData["roles"] = await _context.Roles.ToListAsync();
            ViewData["userRoles"] = await _userManager.GetRolesAsync(useris);
            return View("EditReqisterUsers", model);
        }
        [Authorize]
        public IActionResult RegisterIndex()
        {
            
            return View("RegisterIndex" , _context.Users.ToList());
        }
        [Authorize]
        public async Task<IActionResult> RegisterForuser()
        {
            var model = await GetCurrentUserAsync();
            RegisterViewModel usermodel = new RegisterViewModel()
            {
                UserName = model.UserName,
                Email = model.Email,
                EmployName = model.EmployName,
                MemberId = model.MemberId
                    ,
                PhoneNumber = model.PhoneNumber,
                IdentityId = model.IdentityId,
                Id = model.Id,
                IdenetityPic = model.IdenetityPic,
                ProfilePic = model.ProfilePic,
                MemberPhotoId = model.MemberPhotoId ,
                SigPic = model.SigImage,
                InterPercentage = model.InterPercentage,
                MuthminPercentage = model.MuthminPercentage,
                AduitPercentage = model.AduitPercentage,
                AproverPercentage = model.AproverPercentage,
                SupervisionPercentage = model.SupervisionPercentage
            };
            return View("RegisterForUser", usermodel);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterForuser(RegisterViewModel model)
        {
            var useris = _context.Users.SingleOrDefault(user => user.Id == model.Id);

            useris.UserName = model.UserName;
            useris.Email = model.Email;
            useris.EmployName = model.EmployName;
            useris.MemberId = model.MemberId;

            useris.PhoneNumber = model.PhoneNumber;
            useris.IdentityId = model.IdentityId;
            useris.InterPercentage = model.InterPercentage;
            useris.MuthminPercentage = model.MuthminPercentage;
            useris.AduitPercentage = model.AduitPercentage;
            useris.AproverPercentage = model.AproverPercentage;
            useris.SupervisionPercentage = model.SupervisionPercentage;

            if (ModelState.IsValid)
            {
              await SaveFiles(useris);
                _context.SaveChanges();
              return View("UserCreatedSecuss");
            }

            return View("RegisterForUser", model);
        }
        
        public async Task CreatFile(string path , IFormFile file)
        {
            var strem = new FileStream(Path.Combine(_env.WebRootPath, path), FileMode.Create);
            await file.CopyToAsync(strem);
            strem.Close();
            strem.Dispose();

        }

        public async Task SaveFiles(ApplicationUser user)
        {
            foreach (IFormFile formFile in Request.Form.Files)
            {
                string guid = Guid.NewGuid().ToString();
                string filepath = "ProfileImg/" + guid + ".jpg";
                if (formFile.Name == "memberphoto" && formFile.Length > 0)
                {
                    await CreatFile(filepath, formFile);
                    user.MemberPhotoId = guid;
                }
                else if (formFile.Name == "profid" && formFile.Length > 0)
                {
                    await CreatFile(filepath, formFile);
                    user.ProfilePic = guid;
                }
                else if (formFile.Name == "idnetitypic" && formFile.Length > 0)
                {
                    await CreatFile(filepath, formFile);
                    user.IdenetityPic = guid;
                }else if (formFile.Name == "sigpic" && formFile.Length > 0)
                {
                    await CreatFile(filepath, formFile);
                    user.SigImage = guid;
                }

            }
        }






        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>


        //
        // POST: /Account/LogOff
        
      [Authorize]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
          
            return RedirectToAction("Login");
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        //
        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                _logger.LogInformation(5, "User logged in with {Name} provider.", info.LoginProvider);
                return RedirectToLocal(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl });
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation(6, "User created an account using {Name} provider.", info.LoginProvider);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        // GET: /Account/ConfirmEmail
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                //var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Reset Password",
                //   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
                //return View("ForgotPasswordConfirmation");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(AccountController.ResetPasswordConfirmation), "Account");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(AccountController.ResetPasswordConfirmation), "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/SendCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(user);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            // Generate the token and send it
            var code = await _userManager.GenerateTwoFactorTokenAsync(user, model.SelectedProvider);
            if (string.IsNullOrWhiteSpace(code))
            {
                return View("Error");
            }

            var message = "Your security code is: " + code;
            if (model.SelectedProvider == "Email")
            {
                await _emailSender.SendEmailAsync(await _userManager.GetEmailAsync(user), "Security Code", message);
            }
            else if (model.SelectedProvider == "Phone")
            {
                await _smsSender.SendSmsAsync(await _userManager.GetPhoneNumberAsync(user), message);
            }

            return RedirectToAction(nameof(VerifyCode), new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/VerifyCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyCode(string provider, bool rememberMe, string returnUrl = null)
        {
            // Require that the user has already logged in via username/password or external login
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes.
            // If a user enters incorrect codes for a specified amount of time then the user account
            // will be locked out for a specified amount of time.
            var result = await _signInManager.TwoFactorSignInAsync(model.Provider, model.Code, model.RememberMe, model.RememberBrowser);
            if (result.Succeeded)
            {
                return RedirectToLocal(model.ReturnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning(7, "User account locked out.");
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid code.");
                return View(model);
            }
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CloudApp.Models;
using CloudApp.Models.AccountViewModels;
using CloudApp.Models.BusinessModel;
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
        private readonly RoleManager<IdentityRole> _roleManager;
       
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        public static string UserName;
        public static string picId;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
          
            ILoggerFactory loggerFactory , ApplicationDbContext context , RoleManager<IdentityRole> roleManager , IHostingEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _context = context;
            _roleManager = roleManager;
            _env = env;
            
        }

   
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
          
            return View();
        }

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
                   UserName = userdata.EmployName;
                    picId = userdata.ProfilePic + ".jpg";
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "خطأ في تسجيل الدخول الرجاء تاكد من صحة المعلومات المدخلة");
                return View(model);
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


        [HttpGet]
        
        public async Task<ViewResult> Register()
        {
            ViewData["roles"] = await _context.Roles.ToListAsync();
            return View();
        }

       
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
                    IsInterPercentage = model.IsInterPercentage,
                    IsMuthminPercentage = model.IsMuthminPercentage,
                    IsAduitPercentage = model.IsAduitPercentage,
                    IsAproverPercentage = model.IsAproverPercentage,
                    IsSupervisionPercentage = model.IsSupervisionPercentage,
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
            ViewData["roles"] = await _context.Roles.ToListAsync();
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
                    SupervisionPercentage = model.SupervisionPercentage,
                    IsInterPercentage = model.IsInterPercentage,
                    IsMuthminPercentage = model.IsMuthminPercentage,
                    IsAduitPercentage = model.IsAduitPercentage,
                    IsAproverPercentage = model.IsAproverPercentage,
                    IsSupervisionPercentage = model.IsSupervisionPercentage,
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
            useris.IsInterPercentage = model.IsInterPercentage;
            useris.IsMuthminPercentage = model.IsMuthminPercentage;
            useris.IsAduitPercentage = model.IsAduitPercentage;
            useris.IsAproverPercentage = model.IsAproverPercentage;
            useris.IsSupervisionPercentage = model.IsSupervisionPercentage;
         
            
            await _userManager.AddPasswordAsync(useris, model.Password);

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
                SupervisionPercentage = model.SupervisionPercentage,
                IsInterPercentage = model.IsInterPercentage,
                IsMuthminPercentage = model.IsMuthminPercentage,
                IsAduitPercentage = model.IsAduitPercentage,
                IsAproverPercentage = model.IsAproverPercentage,
                IsSupervisionPercentage = model.IsSupervisionPercentage,

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
            useris.IsInterPercentage = model.IsInterPercentage;
            useris.IsMuthminPercentage = model.IsMuthminPercentage;
            useris.IsAduitPercentage = model.IsAduitPercentage;
            useris.IsAproverPercentage = model.IsAproverPercentage;
            useris.IsSupervisionPercentage = model.IsSupervisionPercentage;
            await _userManager.RemovePasswordAsync(useris);
           await _userManager.AddPasswordAsync(useris, model.Password);

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

        
      [Authorize]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
          
            return RedirectToAction("Login");
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

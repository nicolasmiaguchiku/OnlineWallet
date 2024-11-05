using Microsoft.AspNetCore.Mvc;
using OnlineWallet.Interfaces;
using OnlineWallet.ViewModels;

namespace OnlineWallet.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices? _userServices;

        public AccountController(IUserServices userServices)
        {
            _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = _userServices != null ? await _userServices.Register(model): null;
                
                if (user != null)
                {
                    TempData["SuccessMessage"] = "User created successfully";
                    return RedirectToAction("Login");
                }
            }
            catch (InvalidOperationException ex) 
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while registering. Please try again." + ex);
            }

            return View(model);
        }
    }
}

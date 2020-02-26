using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected UserManager<ApplicationUser> _userManager { get; }
        protected BaseController(
        UserManager<ApplicationUser> userManager
      )
        {

            _userManager = userManager;
        }
        protected BaseController()
        {
        }
    }

}

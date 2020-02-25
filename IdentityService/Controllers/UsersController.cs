using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityService.Controllers
{
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context,
                             UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
            _context = context;
        }
        [Route("AddUser")]
        public IActionResult AddUser()
        {
          var res =  _userManager.CreateAsync(new ApplicationUser { Email = "admin@admi.com", UserName = "admin" }, "ZAQ!2wsx").Result;

            return Ok(10);
        }

        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            //var context = await _interaction.GetAuthorizationContextAsync("/connect/authorize/callback?client_id=spaclient&redirect_uri=https%3A%2F%2Flocalhost%3A5003%2Fcallback.html&response_type=code&scope=openid%20profile%20identity.api%20test.api&state=aad902a1a7f9448fb4b12bcbbc34c229&code_challenge=CcHj5rOVfg6qrPOfr8sKqwaDXwg-FUsvYXvXt0E8MDw&code_challenge_method=S256");
            //  var res = _userManager.CreateAsync(new ApplicationUser { Email = "admin@admi.com", UserName = "admin" }, "ZAQ!2wsx").Result;
            var result = await _signInManager.PasswordSignInAsync("admin", "ZAQ!2wsx", true, lockoutOnFailure: true);
            if (result.Succeeded)
            {

                //if (context != null)
                //{
                //    if (await _clientStore.IsPkceClientAsync(context.ClientId))
                //    {
                        // if the client is PKCE then we assume it's native, so this change in how to
                        // return the response is for better UX for the end user.
                        return Ok(100);
                   // }

                    // we can trust model.ReturnUrl since GetAuthorizationContextAsync returned non-null
                    return Ok(35345);
                //}
            }
                return Ok(10);
        }

    }
}

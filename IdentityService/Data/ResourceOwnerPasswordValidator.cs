using IdentityServer4.Validation;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityService.Data
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private MyUserManager _myUserManager { get; set; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ResourceOwnerPasswordValidator(SignInManager<ApplicationUser> signInManager)
        {
            _myUserManager = new MyUserManager();
            _signInManager = signInManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userName = context.UserName;
            var password = context.Password;
            var user = await _myUserManager.FindByNameAsync(userName);
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                context.Result = new GrantValidationResult(
                 subject: userName,
                 authenticationMethod: "",
                 claims: new List<Claim>() { new Claim("accountnumber", "12345") });
            }
            //if (user != null && await _myUserManager.CheckPasswordAsync(user, password))
            //{

            //}

        }
    }
}

using IdentityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityService.Data
{
    public class MyUserManager
    {
        public Task<MyUser> FindByNameAsync(string username)
        {
            //This is where you would do a database call in real world scenario

            //var context = new ApplicationContext();
            //var user = context.MyUsers.SingleOrDefaultAsync(x => x.Username == username)
            var user = GetUsers().SingleOrDefault(x => x.UserName == username);

            return Task.FromResult(user);
        }

        public Task<bool> CheckPasswordAsync(MyUser user, string password)
        {
            //This is where you call a hashing method to verify password
            //var isPasswordMatch = MyPasswordHasher.VerifyHashedPassword(user.PasswordHash, password);

            if (user.Password == password)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }

        private List<MyUser> GetUsers()
        {
            var users = new List<MyUser>();

            users.Add(new MyUser { UserName = "admin", Password = "Bunny11!" });
            users.Add(new MyUser { UserName = "bob", Password = "Bunny11!" });
            users.Add(new MyUser { UserName = "eve", Password = "Bunny11!" });

            return users;
        }

        public Task<List<Claim>> GetClaimsAsync(MyUser user)
        {
            //Database call to get calims if needed
            var calims = new List<Claim>();
            calims.Add(new Claim("accountnumber", "12345"));

            return Task.FromResult(calims);
        }

    }
}

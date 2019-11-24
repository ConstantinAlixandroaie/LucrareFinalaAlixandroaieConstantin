using LucrareFinalaAlixandroaieConstantin.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LucrareFinalaAlixandroaieConstantin.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LucrareFinalaAlixandroaieConstantin.Controllers
{
    public class AuthenticationController
    {
        protected readonly ArticlesDbContext _ctx;

        public AuthenticationController(ArticlesDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<AuthenticationResult> Authenticate(LoginViewModel vm)
        {
            var hashAlgorithm = new SHA1CryptoServiceProvider();
            var hashpwd = Encoding.Default.GetString(hashAlgorithm.ComputeHash(Encoding.Default.GetBytes(vm.Password)));

            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Username == vm.Username && x.Password == hashpwd);
            if (user == null)
                return new AuthenticationResult() { IsAuthenticated = false };
            else
                return new AuthenticationResult() { IsAuthenticated = true, UserId = user.UserId, Username = user.Username };
        }
    }

    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
    }
}

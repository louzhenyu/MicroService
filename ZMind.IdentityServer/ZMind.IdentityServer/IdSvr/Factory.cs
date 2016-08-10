using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.EntityFramework;
using ZMind.IdentityServer.AspId;
using ZMind.IdentityServer.AspNetIdentity;

namespace ZMind.IdentityServer.IdSvr
{
    class Factory
    {
        public static IdentityServerServiceFactory Configure(string connString)
        {
            var efConfig = new EntityFrameworkServiceOptions
            {
                ConnectionString = connString,
            };

            var factory = new IdentityServerServiceFactory();

            factory.RegisterConfigurationServices(efConfig);
            factory.RegisterOperationalServices(efConfig);

            factory.UserService = new Registration<IUserService, UserService>();
            factory.Register(new Registration<UserManager>());
            factory.Register(new Registration<UserStore>());
            factory.Register(new Registration<Context>(resolver => new Context(connString)));

            return factory;
        }
    }

    public class UserService : AspNetIdentityUserService<User, string>
    {
        public UserService(UserManager userMgr)
            : base(userMgr)
        {
        }

        protected override async Task<IEnumerable<System.Security.Claims.Claim>> GetClaimsFromAccount(User user)
        {
            var claims = (await base.GetClaimsFromAccount(user)).ToList();
            if (!String.IsNullOrWhiteSpace(user.Claims.Select(o => o.ClaimType = "ClientId").FirstOrDefault()))
            {
                claims.Add(new System.Security.Claims.Claim("ClientId", user.Claims.Select(o => o.ClaimType = "ClientId").FirstOrDefault()));
            }
            return claims;
        }
    }
}

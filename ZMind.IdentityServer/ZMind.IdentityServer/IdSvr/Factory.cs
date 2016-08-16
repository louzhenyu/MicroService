using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Claims;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using IdentityServer3.Contrib.Cache.Redis;
using IdentityServer3.Contrib.Cache.Redis.CacheClient;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.EntityFramework;
using StackExchange.Redis;
using ZMind.IdentityServer.AspId;
using ZMind.IdentityServer.AspNetIdentity;
using Claim = System.Security.Claims.Claim;

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

            var redisConnString = ConfigHelper.ConfigHelper.RedisConnString;
            var options = ConfigurationOptions.Parse(redisConnString);
            options.AllowAdmin = true;
            var connection = ConnectionMultiplexer.Connect(options);
            var cacheClient = new RedisCacheManager(connection);
            var clientStoreCache = new ClientStoreCache(cacheClient);
            var scopeStoreCache = new ScopeStoreCache(cacheClient);
            var userServiceCache = new UserServiceCache(cacheClient);

            factory.ConfigureClientStoreCache(new Registration<ICache<Client>>(clientStoreCache));
            factory.ConfigureScopeStoreCache(new Registration<ICache<IEnumerable<Scope>>>(scopeStoreCache));
            factory.ConfigureUserServiceCache(new Registration<ICache<IEnumerable<Claim>>>(userServiceCache));
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

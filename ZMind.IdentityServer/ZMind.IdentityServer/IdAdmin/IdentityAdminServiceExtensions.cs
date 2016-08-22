using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityAdmin.Configuration;
using IdentityAdmin.Core;

namespace ZMind.IdentityServer.IdAdmin
{
    public static class IdentityAdminServiceExtensions
    {
        public static void Configure(this IdentityAdminServiceFactory factory)
        {
            factory.IdentityAdminService = new Registration<IIdentityAdminService, IdentityAdminManagerService>();
        }
    }
}
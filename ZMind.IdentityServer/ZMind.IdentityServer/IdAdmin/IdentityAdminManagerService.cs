using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Admin.EntityFramework;
using IdentityServer3.Admin.EntityFramework.Entities;

namespace ZMind.IdentityServer.IdAdmin
{
    public class IdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public IdentityAdminManagerService()
            : base("IdSvr3Config")
        {

        }
    }
}
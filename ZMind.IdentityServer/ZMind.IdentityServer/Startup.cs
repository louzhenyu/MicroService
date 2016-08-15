/*
 * Copyright 2014 Dominick Baier, Brock Allen
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using IdentityAdmin.Configuration;
using IdentityManager.Configuration;
using IdentityManager.Core.Logging;
using IdentityManager.Logging;
using IdentityServer3.Core.Configuration;
using Owin;
using Serilog;
using ZMind.IdentityServer.IdMgr;
using ZMind.IdentityServer.IdSvr;
using ZMind.IdentityServer.IdAdmin;
using Factory = ZMind.IdentityServer.IdSvr.Factory;

namespace ZMind.IdentityServer
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Trace()
               .CreateLogger();

            app.Map("/UserAdmin", adminApp =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureSimpleIdentityManagerService("IdSvr3Config");

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory,
                    SecurityConfiguration = new IdentityManager.Configuration.LocalhostSecurityConfiguration
                    {
                        RequireSsl = false
                    }
                });
            });

            app.Map("/Admin", adminApp =>
            {
                var factory = new IdentityAdminServiceFactory();
                factory.Configure();
                adminApp.UseIdentityAdmin(new IdentityAdminOptions
                {
                    Factory = factory,
                    AdminSecurityConfiguration = new IdentityAdmin.Configuration.LocalhostSecurityConfiguration
                    {
                        RequireSsl = false
                    }
                });
            });

            var idSvrFactory = Factory.Configure("IdSvr3Config");
            var options = new IdentityServerOptions
            {
                SiteName = "ZMind-IdentityServer",
                Factory = idSvrFactory,
                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}
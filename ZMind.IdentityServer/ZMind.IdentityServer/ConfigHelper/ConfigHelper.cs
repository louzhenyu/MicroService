using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ZMind.IdentityServer.ConfigHelper
{
    public static class ConfigHelper
    {
        private static string _redisConnString;

        public static string RedisConnString
        {
            get
            {
                if (string.IsNullOrEmpty(_redisConnString))
                {
                    _redisConnString = ConfigurationManager.AppSettings["RedisConnString"];
                }
                return _redisConnString;
            }
        }
    }
}
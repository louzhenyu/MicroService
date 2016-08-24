using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using ZMind.Activity.Application;
using ZMind.Activity.DTO.Response;

namespace ZMind.Activity.WebAPI.Controllers
{
    public class ActivityController : ApiController
    {
        private ActivityApplication activityApp = new ActivityApplication();
        [HttpPost]
        public ActivityResponse Post([FromBody]string activityId)
        {
            var caller = User as ClaimsPrincipal;

            var subjectClaim = caller.FindFirst("sub");
            if (subjectClaim != null)
            {
                var test = caller.FindFirst("ClientId");
            }
            activityId = "5B4ABBFA-914C-463F-914E-ADBE21A81C70";
            return activityApp.GetActivity(new Guid(activityId));
        }
    }
}

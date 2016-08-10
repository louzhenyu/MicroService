using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZMind.Activity.DomainEntity.Activity;
using ZMind.Activity.DTO.Response;
using ZMind.Activity.Repository.ActivityRepository;

namespace ZMind.Activity.Application
{
    public class ActivityApplication
    {
        public ActivityResponse GetActivity(Guid activityId)
        {
            var activityRepository = new ActivityRepository();
            var activityDomainEntity = activityRepository.GetActivity(activityId);
            Mapper.Initialize(cfg => cfg.CreateMap<ActivityDomainEntity, ActivityResponse>());
            var result = Mapper.Map<ActivityResponse>(activityDomainEntity);
            return result;
        }
    }
}

using System;
using AutoMapper;
using ZMind.Activity.DBAccess.C_Activity;
using ZMind.Activity.DBEntity;
using ZMind.Activity.DomainEntity.Activity;

namespace ZMind.Activity.Repository.ActivityRepository
{
    public class ActivityRepository : IActivityDomainEntityRepository
    {
        private C_ActivityFacade dbFacade = new C_ActivityFacade();
        public void UpdateActivity(ActivityDomainEntity activity)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ActivityDomainEntity, C_ActivityDbEntity>());
            C_ActivityDbEntity activityDbEntity = Mapper.Map<C_ActivityDbEntity>(activity);
            dbFacade.UpdateC_Activity(activityDbEntity);
        }

        public void InsertActivity(ActivityDomainEntity activity)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ActivityDomainEntity, C_ActivityDbEntity>());
            C_ActivityDbEntity activityDbEntity = Mapper.Map<C_ActivityDbEntity>(activity);
            dbFacade.AddC_Activity(activityDbEntity);
        }

        public ActivityDomainEntity GetActivity(Guid activityId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<C_ActivityDbEntity, ActivityDomainEntity>());
            var result = Mapper.Map<ActivityDomainEntity>(dbFacade.GetC_Activity(activityId));
            return result;
        }
    }
}

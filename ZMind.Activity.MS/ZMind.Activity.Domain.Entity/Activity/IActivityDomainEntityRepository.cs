using System;

namespace ZMind.Activity.DomainEntity.Activity
{
    public interface IActivityDomainEntityRepository
    {
        void UpdateActivity(ActivityDomainEntity activity);
        void InsertActivity(ActivityDomainEntity activity);
        ActivityDomainEntity GetActivity(Guid activityId);
    }
}

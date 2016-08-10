using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZMind.Activity.DBEntity;
using ZMind.Activity.DomainEntity.Activity;

namespace ZMind.Activity.Mapping
{
    public static class ActivityMap
    {
        static ActivityMap()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ActivityDomainEntity, C_ActivityDbEntity>());
            Mapper.Initialize(cfg => cfg.CreateMap<C_ActivityDbEntity, ActivityDomainEntity>());
        }
    }
}

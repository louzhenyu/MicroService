using System;
using ZMind.Activity.DBEntity;

namespace ZMind.Activity.DBAccess.C_Activity
{
    public class C_ActivityFacade
    {
        static readonly C_ActivityCMD DbCmd = new C_ActivityCMD();
        static readonly C_ActivityQuery DbQuery = new C_ActivityQuery();

        public void UpdateC_Activity(C_ActivityDbEntity cActivityDbEntity)
        {
            DbCmd.UpdateC_Activity(cActivityDbEntity);
        }

        public void AddC_Activity(C_ActivityDbEntity cActivityDbEntity)
        {
            DbCmd.AddC_Activity(cActivityDbEntity);
        }

        public C_ActivityDbEntity GetC_Activity(Guid activityId)
        {
            return DbQuery.GetC_Activity(activityId);
        }
    }
}

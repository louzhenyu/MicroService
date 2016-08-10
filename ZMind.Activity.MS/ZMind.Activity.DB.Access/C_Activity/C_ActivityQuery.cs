using System;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using ZMind.Activity.DBEntity;

namespace ZMind.Activity.DBAccess.C_Activity
{
    public class C_ActivityQuery
    {
        internal C_ActivityDbEntity GetC_Activity(Guid activityId)
        {
            using (var conn = new SqlConnection(ConnectionString.Cpos_bs_alading_select))
            {
                conn.Open();
                return conn.Get<C_ActivityDbEntity>(activityId);
            }
        }
    }
}

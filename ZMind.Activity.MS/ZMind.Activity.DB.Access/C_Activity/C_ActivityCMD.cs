using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using ZMind.Activity.DBEntity;

namespace ZMind.Activity.DBAccess.C_Activity
{
    public class C_ActivityCMD
    {
        internal void UpdateC_Activity(C_ActivityDbEntity cActivityDbEntity)
        {
            using (var conn = new SqlConnection(ConnectionString.Cpos_bs_alading_insert))
            {
                conn.Open();
                conn.Update(cActivityDbEntity);
            }
        }
        internal void AddC_Activity(C_ActivityDbEntity cActivityDbEntity)
        {
            using (var conn = new SqlConnection(ConnectionString.Cpos_bs_alading_insert))
            {
                conn.Open();
                conn.Insert(cActivityDbEntity);
            }
        }
    }
}

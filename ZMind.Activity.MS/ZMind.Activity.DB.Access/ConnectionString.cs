using System.Configuration;

namespace ZMind.Activity.DBAccess
{
    public class ConnectionString
    {
        #region cpos_bs_alading库
        

        /// <summary>
        /// cpos_bs_alading库只读连接
        /// </summary>
        public static string Cpos_bs_alading_select
        {
            get
            {
                if (string.IsNullOrEmpty(cpos_bs_alading_select))
                {
                    cpos_bs_alading_select = ConfigurationManager.ConnectionStrings["cpos_bs_alading_select"].ConnectionString;
                }
                return cpos_bs_alading_select;
            }
        }
        /// <summary>
        /// cpos_bs_alading库写连接
        /// </summary>
        public static string Cpos_bs_alading_insert
        {
            get
            {
                if (string.IsNullOrEmpty(cpos_bs_alading_insert))
                {
                    cpos_bs_alading_insert = ConfigurationManager.ConnectionStrings["cpos_bs_alading_insert"].ConnectionString;
                }
                return cpos_bs_alading_insert;
            }
        }
        private static string cpos_bs_alading_select;
        private static string cpos_bs_alading_insert;
        #endregion
    }
}

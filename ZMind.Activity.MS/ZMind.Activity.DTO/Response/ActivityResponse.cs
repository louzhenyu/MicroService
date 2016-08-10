using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMind.Activity.DTO.Response
{
    public class ActivityResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid? ActivityID { get; set; }

        /// <summary>
        /// 1=生日活动 2=营销活动 3=充值活动
        /// </summary>
        public Int32? ActivityType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String ActivityName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 0=不是；1=是
        /// </summary>
        public Int32? IsLongTime { get; set; }

        /// <summary>
        /// 大于0表示启用和倍数
        /// </summary>
        public Decimal? PointsMultiple { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? SendCouponQty { get; set; }

        /// <summary>
        /// 0=正常；   1=暂停；   未开始、运行中和结束状态均根据开始时间和结束时间判断
        /// </summary>
        public Int32? Status { get; set; }

        /// <summary>
        /// 0=不是；1=是
        /// </summary>
        public Int32? IsAllVipCardType { get; set; }

        /// <summary>
        /// 0=不是；1=是
        /// </summary>
        public Int32? IsVipGrouping { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String CustomerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String CreateBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String LastUpdateBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 0=正常状态；1=删除状态
        /// </summary>
        public Int32? IsDelete { get; set; }
    }
}

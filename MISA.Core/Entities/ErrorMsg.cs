using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Class thông báo lỗi
    /// CreatedBy:LCQUYEN(24/03/2021)
    /// </summary>
    public class ErrorMsg
    {
        /// <summary>
        /// Câu thông báo lỗi dành cho dev
        /// </summary>
        public string devMsg { get; set; }
        /// <summary>
        /// Câu thông báo lỗi dành cho user
        /// </summary>
        public string userMsg { get; set; }
        /// <summary>
        /// Mã code
        /// </summary>
        public string errorCode { get; set; }
        /// <summary>
        /// Thông tin chi tiết
        /// </summary>
        public string moreInfo { get; set; }
        /// <summary>
        /// Ghi log
        /// </summary>
        public string traceId { get; set; } 
    }
}

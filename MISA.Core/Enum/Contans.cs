using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Enum
{
    /// <summary>
    /// Xác định trạng thái làm việc của validate dữ liệu
    /// CreatedBy: LCQUYEN(24/03/2021)
    /// </summary>
    public static class MISAConst
    {
        public static readonly string Success = "200";
        public static readonly string CreatedSuccess = "201";
        public static readonly string NoContent = "204";
        public static readonly string IsNotValid = "400";
        public static readonly string IsNotEnpointServer= "404";
        public static readonly string Exception = "500";
    }
    /// <summary>
    /// Xác định trạng thái của Object
    /// CreatedBy: LCQUYEN(24/03/2021)
    /// </summary>
    public enum EntityState
    {
        AddNew = 1,
        Update = 2,
        Delete = 3,
    }
}

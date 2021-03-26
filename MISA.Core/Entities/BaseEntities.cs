using MISA.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.Core.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Primary : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }
    public class BaseEntities
    {
        /// <summary>
        /// Trạng thái của object (thêm,sửa,xóa...)
        /// </summary>
        public EntityState EntityState { get; set; }
        #region Other
        /// <summary>
        /// Ngày tạo
        /// </summary>
        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        [DisplayName("Ngày sửa")]
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        [DisplayName("Người sửa")]
        public string ModifiedBy { get; set; }
        #endregion
    }
}

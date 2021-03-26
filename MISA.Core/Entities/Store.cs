using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class Store : BaseEntities
    {
        /// <summary>
        /// Thông tin cửa hàng
        /// CreatedBy:LCQUYEN(25/03/2021)
        /// </summary>
        #region Constructor
        #endregion
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        [Primary]
        public Guid StoreId { get; set; }
        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        [Required]
        [CheckDuplicate]
        [DisplayName("Mã cửa hàng")]
        public String StoreCode { get; set; }
        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        [Required]
        [DisplayName("Tên cửa hàng")]
        public String StoreName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [Required]
        [DisplayName("Địa chỉ")]
        public String Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public String PhoneNumber { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public String TaxCode { get; set; }
        /// <summary>
        /// Trang thái (1-đang hoạt động , 0-đã đóng cửa)
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng quốc gia
        /// </summary>
        public String CountryId { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng tỉnh,thành phố
        /// </summary>
        public String ProvinceId { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng quận,huyện
        /// </summary>
        public String DistrictId { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng xã phường
        /// </summary>
        public String WardId { get; set; }
        /// <summary>
        /// Đường phố
        /// </summary>
        public String Street { get; set; }
        #endregion
    }
}



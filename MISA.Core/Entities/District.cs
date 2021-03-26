using System;

/// <summary>
/// Thông tin quận huyện
/// CreatedBy:LCQUYEN(25/03/2021)
/// </summary>
public class District
{
     #region Constructor
     #endregion
     #region Property
     /// <summary>
     /// Mã quận,huyện (Khóa chính)
     /// </summary>
    public String DistrictId { get; set; }
    /// <summary> 
    /// Tên quận,huyện 
    /// </summary>
    public String DistrictName { get; set; }
    /// <summary>
    /// Khóa ngoại tỉnh,thành phố
    /// </summary>
    public String ProvinceId { get; set; }
    #endregion
}

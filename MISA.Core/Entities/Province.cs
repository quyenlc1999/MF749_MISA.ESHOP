using System;

/// <summary>
/// Thông tin tỉnh,thành phố
/// CreatedBy:LCQUYEN(25/03/2021)
/// </summary>
public class Province
{
    #region Constructor
    #endregion
    #region Property
    /// <summary>
    /// Mã tỉnh,thành phố (Khóa chính)
    /// </summary>
    public String ProvinceId { get; set; }
    /// <summary> 
    /// Tên tỉnh,thành phố
    /// </summary>
    public String ProvinceName { get; set; }
    /// <summary>
    ///Khóa ngoại quốc gia
    /// </summary>
    public String CountryId { get; set; }
    #endregion
}

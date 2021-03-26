using System;
/// <summary>
/// Thông tin xã,phường
/// CreatedBy:LCQUYEN(25/03/2021)
/// </summary>
public class Ward
{
    #region Constructor
    #endregion
    #region Property
    /// <summary>
    /// Mã xã,phường (Khóa chính)
    /// </summary>
    public String WardId { get; set; }
    /// <summary> 
    /// Tên xã,phường
    /// </summary>  
    public String WardName { get; set; }
    /// <summary>
    /// Khóa ngoại quận,huyện
    /// </summary>
    public String DistrictId { get; set; }
    #endregion
}

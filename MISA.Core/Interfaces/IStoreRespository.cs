using MISA.Core.Entities;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces
{
    public interface IStoreRespository: IBaseRespository
    {
        /// <summary>
        /// Lấy đanh sách các quốc gia
        /// CreatedBy:LCQUYEN(25/03/2021)
        /// </summary>
        /// <returns></returns>
        IEnumerable<Country> GetCountries();
        /// <summary>
        /// Lấy đanh sách các tỉnh,thành phố
        /// CreatedBy:LCQUYEN(25/03/2021)
        /// </summary>
        /// <returns></returns>
        IEnumerable<Province> GetProvinces();
        /// <summary>
        /// Lấy đanh sách các quận huyện
        /// CreatedBy:LCQUYEN(25/03/2021)
        /// </summary>
        /// <returns></returns>
        IEnumerable<District> GetDistricts();
        /// <summary>
        /// Lấy đanh sách các cã,phường
        /// CreatedBy:LCQUYEN(25/03/2021)
        /// </summary>
        /// <returns></returns>
        IEnumerable<Ward> GetWards();
        /// <summary>
        /// Lấy đanh sách các tỉnh,thành phố theo quốc gia
        /// CreatedBy:LCQUYEN(25/03/2021)
        /// </summary>
        /// <returns></returns>
        IEnumerable<Province> GetProvinceWithCountry(String id);
        /// <summary>
        /// Lấy đanh sách các quậ,huyện theo tỉn,thành phố
        /// CreatedBy:LCQUYEN(25/03/2021)
        /// </summary>
        /// <returns></returns>
        IEnumerable<District> GetDistrictWithProvince(String id);
        /// <summary>
        /// Lấy đanh sách xã,phường theo quận huyện
        /// CreatedBy:LCQUYEN(25/03/2021)
        /// </summary>
        /// <returns></returns>
        IEnumerable<Ward> GetWardWithDistrict(String id);
        IEnumerable<Store> GetStoresFilters(string specs);
       // IEnumerable<Store> GetStoresFilters(string filterStoreCode, string filterStoreName, string filterAddress, string filterPhoneNumber, int filterStatus);
    }
}

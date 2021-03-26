using MISA.Core.Entities;
using MISA.Core.Interface;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class StoreService:BaseService , IStoreService
    {
        IStoreRespository _storeRespository;
        public StoreService(IStoreRespository storeRespository, IBaseRespository baseRespository) : base(baseRespository)
        {
            _storeRespository = storeRespository;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _storeRespository.GetCountries();
        }

        public IEnumerable<District> GetDistricts()
        {
            return _storeRespository.GetDistricts();
        }

        /*public IEnumerable<Store> GetStoresFilters(string filterStoreCode, string filterStoreName, string filterAddress, string filterPhoneNumber, int filterStatus)
        {
            return _storeRespository.GetStoresFilters(filterStoreCode, filterStoreName, filterAddress, filterPhoneNumber, filterStatus);
        }*/

        public IEnumerable<District> GetDistrictWithProvince(string id)
        {
            return _storeRespository.GetDistrictWithProvince(id);
        }

        public IEnumerable<Province> GetProvinces()
        {
            return _storeRespository.GetProvinces();
        }

        public IEnumerable<Province> GetProvinceWithCountry(string id)
        {
            return _storeRespository.GetProvinceWithCountry(id);
        }

        public IEnumerable<Store> GetStoresFilters(string specs)
        {
            return _storeRespository.GetStoresFilters(specs);
        }

        public IEnumerable<Ward> GetWards()
        {
            return _storeRespository.GetWards();
        }

        public IEnumerable<Ward> GetWardWithDistrict(string id)
        {
            return _storeRespository.GetWardWithDistrict(id);
        }
    }
}

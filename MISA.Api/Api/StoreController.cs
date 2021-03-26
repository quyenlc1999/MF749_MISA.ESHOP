using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Enum;
using MISA.Core.Interface;
using MISA.Core.Interfaces;
using MISA.CukCuk.Api.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Api.Api
{
    public class StoreController: BaseController<Store>
    {
        IStoreService _storeService;
        public StoreController(IStoreService storeService, IBaseService baseService) : base(baseService)
        {
            _storeService = storeService;
        }
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var res = _storeService.GetCountries();
            if(res.Count() > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), res);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), res);
            }
        }
        [HttpGet("provinces")]
        public IActionResult GetProvinces()
        {
            var res = _storeService.GetProvinces();
            if(res.Count() > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), res);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), res);
            }
        }

        [HttpGet("provinceWithCountry")]
        public IActionResult GetProvinceWithCountry(string id)
        {
            var res = _storeService.GetProvinceWithCountry(id);
            if (res.Count() > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), res);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), res);
            }
        }

        [HttpGet("districts")]
        public IActionResult GetDistricts()
        {
            var res = _storeService.GetDistricts();
            if (res.Count() > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), res);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), res);
            }
        }

        [HttpGet("districtWithProvince")]
        public IActionResult GetDistrictWithProvince(string id)
        {
            var res = _storeService.GetDistrictWithProvince(id);
            if (res.Count() > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), res);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), res);
            }
        }

        [HttpGet("wards")]
        public IActionResult GetWards()
        {
            var res = _storeService.GetWards();
            if (res.Count() > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), res);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), res);
            }
        }

        [HttpGet("wardWithDistrict")]
        public IActionResult GetWardWithDistrict(string id)
        {
            var res = _storeService.GetWardWithDistrict(id);
            if (res.Count() > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), res);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), res);
            }
        }
        /*
                [HttpGet("search")]
                public IActionResult GetStoresFilters(string filterStoreCode, string filterStoreName, string filterAddress, string filterPhoneNumber, int filterStatus)
                {
                    var res = _storeService.GetStoresFilters(filterStoreCode, filterStoreName, filterAddress, filterPhoneNumber, filterStatus);
                    if (res.Count() > 0)
                    {
                        return StatusCode(int.Parse(MISAConst.Success), res);
                    }
                    else
                    {
                        return StatusCode(int.Parse(MISAConst.NoContent), res);
                    }
                }*/

        [HttpGet("search")]
        public IActionResult GetStoresFilters(string specs)
        {
            var res = _storeService.GetStoresFilters(specs);
            if (res.Count() > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), res);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), res);
            }
        }


    }
}

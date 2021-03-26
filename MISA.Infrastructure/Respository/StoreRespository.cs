using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure.Respository
{
    public class StoreRespository : BaseRespository, IStoreRespository
    {
        public IEnumerable<Country> GetCountries()  
        {
            string procName = $"Proc_GetCountries";
            var res = _dbConnection.Query<Country>(procName, commandType: CommandType.StoredProcedure);
            return res;
        }

     /*   public IEnumerable<Store> GetStoresFilters(string filterStoreCode, string filterStoreName, string filterAddress, string filterPhoneNumber, int filterStatus)
        {
            string procName = $"Proc_GetStoresFilters";
            var parameters = new DynamicParameters();
            string storeCode = filterStoreCode != null ? filterStoreCode : string.Empty;
            parameters.Add("@StoreCode", storeCode,DbType.String);
            string storeName = filterStoreCode != null ? filterStoreCode : string.Empty;
            parameters.Add("@StoreName", storeName, DbType.String);
            string address = filterStoreCode != null ? filterStoreCode : string.Empty;
            parameters.Add("@Address", address, DbType.String);
            string phoneNumber = filterStoreCode != null ? filterStoreCode : string.Empty;
            parameters.Add("@PhoneNumber", phoneNumber,DbType.String);
            string status = filterStatus >= 0 ? filterAddress : filterAddress;
            parameters.Add("@Status", status,DbType.Int32);
            var res = _dbConnection.Query<Store>(procName,parameters,commandType:CommandType.StoredProcedure);
            return res;
        }*/

        public IEnumerable<District> GetDistrictWithProvince(String id)
        {
            string procName = $"Proc_GetDistrictWithProvince";
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var res = _dbConnection.Query<District>(procName, parameter, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Province> GetProvinceWithCountry(String id)
        {
            string procName = $"Proc_GetProvinceWithCountry";
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var res = _dbConnection.Query<Province>(procName, parameter, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Ward> GetWardWithDistrict(String id)
        {
            string procName = $"Proc_GetWardWithDistrict";
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var res = _dbConnection.Query<Ward>(procName, parameter, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Store> GetStoresFilters(string specs)
        {
            string procName = $"Proc_GetStoresFilters";
            var parameters = new DynamicParameters();
            string input = specs != null ? specs : string.Empty;
            parameters.Add("@StoreCode", input, DbType.String);
            parameters.Add("@StoreName", input, DbType.String);
            parameters.Add("@Address", input, DbType.String);
            parameters.Add("@PhoneNumber", input, DbType.String);
            parameters.Add("@Status", input, DbType.String);
            var res = _dbConnection.Query<Store>(procName, parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Province> GetProvinces()
        {
            string procName = $"Proc_GetProvinces";
            var res = _dbConnection.Query<Province>(procName, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<District> GetDistricts()
        {
            string procName = $"Proc_GetDistricts";
            var res = _dbConnection.Query<District>(procName, commandType: CommandType.StoredProcedure);
            return res;
        }

        public IEnumerable<Ward> GetWards()
        {
            string procName = $"Proc_GetWards";
            var res = _dbConnection.Query<Ward>(procName, commandType: CommandType.StoredProcedure);
            return res;
        }
    }
}

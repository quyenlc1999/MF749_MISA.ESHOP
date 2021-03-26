using Common.Enum;
using Dapper;
using MISA.Core.Entities;
using MISA.Core.Enum;
using MISA.Core.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure.Respository
{
    public class BaseRespository: IBaseRespository
    {
        protected string connString = @"Host=47.241.69.179; Port=3306;Database=MF749_LCQUYEN_ESHOP;User Id=dev;Password=12345678";
        protected IDbConnection _dbConnection;
        public BaseRespository()
        {
            _dbConnection = new MySqlConnection(connString);
        }

        public IEnumerable<MISAEntity> GetAll<MISAEntity>()
        {
            var className = typeof(MISAEntity).Name;
            string procName = $"Proc_Get{className}s";
            var objects = _dbConnection.Query<MISAEntity>(procName, commandType: CommandType.StoredProcedure);
            return objects;

            /*       catch(Exception e)
                   {
                       errorMsg = new ErrorMsg();
                       errorMsg.devMsg = "Exception error";
                       errorMsg.userMsg = Common.Properties.Resources.ErrorMsg_Exception;
                       errorMsg.errorCode = MISAConst.Exception;
                       return (IEnumerable<MISAEntity>)errorMsg;
                   }*/
        }
        /*
                public MISAEntity ObjectByI d<MISAEntity>(Guid entityId)
                {
                    var className = typeof(MISAEntity).Name;
                    string procName = $"Proc_Get{className}ById";
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add($"@Id", entityId.ToString());
                    var res = _dbConnection.Query<MISAEntity>(procName,param:dynamicParameters,commandType:CommandType.StoredProcedure);
                    var res;
                }*/

        public int Insert<MISAEntity>(MISAEntity entity) where MISAEntity : BaseEntities
        {
            var className = typeof(MISAEntity).Name;
            string procName = $"Proc_Insert{className}";
            var parameters = MappingDbType<MISAEntity>(entity);
            var res = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public int Update<MISAEntity>(MISAEntity entity) where MISAEntity : BaseEntities
        {
            var className = typeof(MISAEntity).Name;
            var procName = $"Proc_Update{className}";
            var parameters = MappingDbType<MISAEntity>(entity);
            var res = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
            return res;
        }


        public int Delete<MISAEntity>(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            var procName = $"Proc_Delete{className}";
            //   var sql = $"DELETE FROM {className} WHERE {className}Id = '{entity}'";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add($"@Id", entityId);
            //   var classNameId = $"{className}Id";
            //   var res = _dbConnection.Execute(sql, commandType: CommandType.Text);
            var res = _dbConnection.Execute(procName,
                                            param: dynamicParams,
                                            commandType: CommandType.StoredProcedure);
            return res;
        }

        public MISAEntity GetObjectById<MISAEntity>(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            string procName = $"Proc_Get{className}ById";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@Id", entityId.ToString());
            var res = _dbConnection.Query<MISAEntity>(procName,
                param: dynamicParameters,
                commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        public MISAEntity GetObjectByProperty<MISAEntity>(MISAEntity entity, PropertyInfo property) where MISAEntity : BaseEntities
        {
            var className = typeof(MISAEntity).Name;
            //   var sqlCommand = $"SELECT * FROM {className} WHERE {propertyName} = '{propertyValue}'";
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{className}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.AddNew)
            {
                query = $"SELECT * FROM {className} WHERE {propertyName} = '{propertyValue}'";
            }
            else if (entity.EntityState == EntityState.Update)
            {
                query = $"SELECT * FROM {className} WHERE {propertyName} = '{propertyValue}' AND {className}Id <> '{keyValue}'";
            }
            else
            {
                return null;
            }
            var res = _dbConnection.Query<MISAEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return res;
        }

        private DynamicParameters MappingDbType<MISAEntity>(MISAEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var dynamicParameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue, DbType.Int32);
                }
                else
                {
                    dynamicParameters.Add($"@{propertyName}", propertyValue);
                }
            }
            return dynamicParameters;
        }
        public IEnumerable<MISAEntity> GetDataByIndexAndOffset<MISAEntity>(int positionStart, int offset)
        {
            var className = typeof(MISAEntity).Name;
            var procName = $"Proc_Get{className}ByIndexOffset";
            var res = _dbConnection.Query<MISAEntity>(procName, new { positionStart = positionStart, offSet = offset }, commandType: CommandType.StoredProcedure);
            return res;
        }
        public int GetCountData<MISAEntity>()
        {
            var className = typeof(MISAEntity).Name;
            var procName = $"Proc_GetCount{className}s";
            var res = _dbConnection.Query<int>(procName, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }
    }
}

using MISA.Core.Entities;
using MISA.Core.Enum;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Core.Services
{
    public class BaseService : IBaseService
    {
        IBaseRespository _baseRespository;
        protected ServiceResult serviceResult;
        protected ErrorMsg errorMsg;
        #region Constructor
        public BaseService(IBaseRespository baseRespository)
        {
            _baseRespository = baseRespository;
        }
        #endregion

        #region
        /// <summary>
        /// Hàm dùng chung trả về tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <returns>Danh sách dư liệu của 1 bảng</returns
        /// CreatedBy:LCQUYEN(10/03/2021)
        public IEnumerable<MISAEntity> GetAll<MISAEntity>()
        {
            return _baseRespository.GetAll<MISAEntity>();
        }
        public MISAEntity GetObjectById<MISAEntity>(Guid entityId)
        {
            return _baseRespository.GetObjectById<MISAEntity>(entityId);
        }
        /// <summary>
        /// Hàm dùng chung thêm mới dữ liệu vào 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        public ServiceResult Insert<MISAEntity>(MISAEntity entity) where MISAEntity:BaseEntities
        {
            entity.EntityState = EntityState.AddNew;
            errorMsg = new ErrorMsg();
            serviceResult = new ServiceResult();
            //Thực hiện validate dữ liệu
            var isValidate = Validate<MISAEntity>(entity);
            if (isValidate != null && isValidate.Sussess == true)
            {
                var rowEffect = _baseRespository.Insert<MISAEntity>(entity);
                if (rowEffect > 0)
                {
                    errorMsg.devMsg = Properties.Resources.Msg_AddSuccess;
                    errorMsg.userMsg = Properties.Resources.Msg_AddSuccess;
                    serviceResult.Sussess = true;
                    serviceResult.Data = rowEffect;
                    serviceResult.MISACode = MISAConst.CreatedSuccess;
                    serviceResult.msg = errorMsg;
                    return serviceResult;
                }
                else
                {
                    errorMsg.devMsg = Properties.Resources.ErrorMsg_NotRecordToDb;
                    errorMsg.userMsg = Properties.Resources.ErrorMsg_NotRecordToDb;
                    serviceResult.Sussess = false;
                    serviceResult.Data = rowEffect;
                    serviceResult.MISACode = MISAConst.IsNotValid;
                    serviceResult.msg = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                return isValidate;
               /* errorMsg.devMsg = Properties.Resources.ErrorMsg_NotRecordToDb;
                errorMsg.userMsg = Properties.Resources.ErrorMsg_NotRecordToDb;
                serviceResult.Sussess = false;
                serviceResult.MISACode = MISAConst.IsNotValid;
                serviceResult.msg = errorMsg;
                return serviceResult;*/
            }
        }
        /// <summary>
        /// Hàm dùng chung cập nhật dữ liệu 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        public ServiceResult Update<MISAEntity>(MISAEntity entity) where MISAEntity : BaseEntities
        {
            entity.EntityState = EntityState.Update;
            errorMsg = new ErrorMsg();
            serviceResult = new ServiceResult();
            //Thực hiện validate dữ liệu
            var isValidate = Validate<MISAEntity>(entity);
            if (isValidate != null && isValidate.Sussess == true)
            {
                var rowEffect = _baseRespository.Update<MISAEntity>(entity);
                if (rowEffect > 0)
                {
                    errorMsg.devMsg = Properties.Resources.Msg_UpdateSuccess;
                    errorMsg.userMsg = Properties.Resources.Msg_UpdateSuccess;
                    serviceResult.Sussess = true;
                    serviceResult.Data = rowEffect;
                    serviceResult.MISACode = MISAConst.Success;
                    serviceResult.msg = errorMsg;
                    return serviceResult;
                }
                else
                {
                    errorMsg.devMsg = Properties.Resources.ErrorMsg_UpdateFailed;
                    errorMsg.userMsg = Properties.Resources.ErrorMsg_UpdateFailed;
                    serviceResult.Sussess = false;
                    serviceResult.Data = rowEffect;
                    serviceResult.MISACode = MISAConst.IsNotValid;
                    serviceResult.msg = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                return isValidate;
                /* errorMsg.devMsg = Properties.Resources.ErrorMsg_NotRecordToDb;
                 errorMsg.userMsg = Properties.Resources.ErrorMsg_NotRecordToDb;
                 serviceResult.Sussess = false;
                 serviceResult.MISACode = MISAConst.IsNotValid;
                 serviceResult.msg = errorMsg;
                 return serviceResult;*/
            }
        }
        /// <summary>
        /// Hàm dùng chung xóa 1 bản ghi của 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entityId">Khóa chính của bảng</param>    
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        public ServiceResult Delete<MISAEntity>(Guid entityId)
        {
            serviceResult = new ServiceResult();
            errorMsg = new ErrorMsg();
            var rowEffect = _baseRespository.Delete<MISAEntity>(entityId);
            if (rowEffect > 0)
            {
                errorMsg.devMsg = Properties.Resources.Msg_DeleteSuccess;
                errorMsg.userMsg = Properties.Resources.Msg_DeleteSuccess;
                serviceResult.Sussess = true;
                serviceResult.Data = rowEffect;
                serviceResult.MISACode = MISAConst.Success;
                serviceResult.msg = errorMsg;
                return serviceResult;
            }   
            else
            {
                errorMsg.devMsg = Properties.Resources.ErrorMsg_DeleteFailed;
                errorMsg.userMsg = Properties.Resources.ErrorMsg_DeleteFailed;
                serviceResult.Sussess = false;
                serviceResult.Data = rowEffect;
                serviceResult.MISACode = MISAConst.IsNotValid;
                serviceResult.msg = errorMsg;
                return serviceResult;
            }
        }
        /// <summary>
        /// Hàm validate dữ liệu đầu vào chỗ phương thức POST và PUT
        /// CreateBy:LCQUYEN (15/03/2021)
        /// </summary>
        /// <typeparam name="MISAEntity">object</typeparam>
        /// <param name="entity"></param>
        /// <returns>object service result</returns>
        private ServiceResult Validate<MISAEntity>(MISAEntity entity) where MISAEntity : BaseEntities
        {
          //  var isValidate = true;
            errorMsg = new ErrorMsg();
            serviceResult = new ServiceResult();
            serviceResult.Sussess = true;
            // Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                //  var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayAttribute>().Single();
                // var displayName = attribute.Name;
                var displayName = GetAttributeDisplayName(property);
                // Kiểm tra attribute xem có cần validate không
                if (property.IsDefined(typeof(Required), false))
                {
                    // Check bắt buộc nhập
                    var propertyValue = property.GetValue(entity);
                    if (propertyValue == null)
                    {
                        // isValidate = false;
                        errorMsg.devMsg = MISA.Core.Properties.Resources.ErrorMsg_Invalid;
                        errorMsg.userMsg = Properties.Resources.ErrorMsg_Invalid;
                        serviceResult.Sussess = false;
                        serviceResult.Data = $"{Properties.Resources.Info} {displayName} {Properties.Resources.ErrorMsg_blank}";
                        serviceResult.MISACode = MISAConst.IsNotValid;
                        serviceResult.msg = errorMsg;
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    // Check trùng dữ liệu
                    var propertyName = property.Name;
                    var propertyDuplicate = _baseRespository.GetObjectByProperty<MISAEntity>(entity,property);
                    if (propertyDuplicate != null)
                    {
                       // isValidate = false;
                        errorMsg.devMsg = Properties.Resources.ErrorMsg_Invalid;
                        errorMsg.userMsg = Properties.Resources.ErrorMsg_Invalid;
                        serviceResult.Sussess = false;
                        serviceResult.Data = $"{Properties.Resources.Info} {displayName} {Properties.Resources.ErrorMsg_Exits}";
                        serviceResult.MISACode = MISAConst.IsNotValid;
                        serviceResult.msg = errorMsg;
                    }
                }
            }
            return serviceResult;
        }
        /// <summary>
        /// Hàm lấy giá trị thuộc tính tên từ một thuộc tính
        /// CreateBy:LCQUYEN (15/03/2021)
        /// </summary>
        /// <param name="property">thuộc tính</param>
        /// <returns>Thuộc tính tên từ một thuộc tính</returns>
        private string GetAttributeDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(
                typeof(DisplayNameAttribute), true);
            if (atts.Length == 0)
                return null;
            return (atts[0] as DisplayNameAttribute).DisplayName;
        }

        public ServiceResult GetDataByIndexAndOffset<MISAEntity>(int positionStart, int offset)
        {
            serviceResult = new ServiceResult();
            serviceResult.Data = _baseRespository.GetDataByIndexAndOffset<MISAEntity>(positionStart, offset);
            return serviceResult;
        }

        public ServiceResult GetCountData<MISAEntity>()
        {
            serviceResult = new ServiceResult();
            serviceResult.Data = _baseRespository.GetCountData<MISAEntity>();
            return serviceResult;
        }

        #endregion
    }
}

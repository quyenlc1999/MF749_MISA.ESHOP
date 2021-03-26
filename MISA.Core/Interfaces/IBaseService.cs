using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interface
{
    public interface IBaseService
    {
        /// <summary>
        /// Hàm dùng chung trả về tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <returns>Danh sách dư liệu của 1 bảng</returns
        /// CreatedBy:LCQUYEN(24/03/2021)
        IEnumerable<MISAEntity> GetAll<MISAEntity>();

        /// <summary>
        /// Hàm dùng chung trả về dữ liệu của 1 bảng theo Id
        /// </summary>
        /// <returns>Danh sách dư liệu của 1 bảng</returns
        /// CreatedBy:LCQUYEN(24/03/2021)
        MISAEntity GetObjectById<MISAEntity>(Guid entityId);

        /// <summary>
        /// Hàm dùng chung thêm mới dữ liệu vào 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(24/03/2021)
        ServiceResult Insert<MISAEntity>(MISAEntity entity) where MISAEntity : BaseEntities;

        /// <summary>
        /// Hàm dùng chung cập nhật dữ liệu 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(24/03/2021)
        ServiceResult Update<MISAEntity>(MISAEntity entity) where MISAEntity : BaseEntities;

        /// <summary>
        /// Hàm dùng chung xóa 1 bản ghi của 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entityId">Khóa chính của bảng</param>    
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(24/03/2021)
        ServiceResult Delete<MISAEntity>(Guid entityId);
        /// <summary>
        /// Hàm validate dùng chung
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>true:thành công , false:thất bại</returns>
        ServiceResult GetDataByIndexAndOffset<MISAEntity>(int positionStart, int offset);
        ServiceResult GetCountData<MISAEntity>(); 
    }
}

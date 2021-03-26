using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.Core.Interface
{
    public interface IBaseRespository
    {
        /// <summary>
        /// Hàm dùng chung trả về tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <returns>Danh sách dữ liệu của 1 bảng</returns
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
        int Insert<MISAEntity>(MISAEntity entity) where MISAEntity : BaseEntities;

        /// <summary>
        /// Hàm dùng chung cập nhật dữ liệu 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(24/03/2021)
        int Update<MISAEntity>(MISAEntity entity) where MISAEntity : BaseEntities;

        /// <summary>
        /// Hàm dùng chung xóa 1 bản ghi của 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity">Khóa chính của bảng</param>    
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(24/03/2021)
        int Delete<MISAEntity>(Guid entityId);
        /// <summary>
        /// Kiểm tra thuộc tính duplicate
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        /// CreatedBy:LCQUYEN(24/03/2021)
        MISAEntity GetObjectByProperty<MISAEntity>(MISAEntity entity, PropertyInfo property) where MISAEntity : BaseEntities;
        /// <summary>
        /// Lấy danh sách theo vị trí bắt đầu và số lượng
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="positionStart">Vị trí bắt đầu</param>
        /// <param name="offset">Số lượng</param>
        /// <returns></returns>
        /// CreatedBy:LCQUYEN(24/03/2021)
        IEnumerable<MISAEntity> GetDataByIndexAndOffset<MISAEntity>(int positionStart, int offset);
        /// <summary>
        /// Lấy số lượng bản ghi trong db
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <returns>Số lượng bản ghi trong db</returns>
        /// CreatedBy:LCQUYEN(24/03/2021)
        int GetCountData<MISAEntity>();

    }
}

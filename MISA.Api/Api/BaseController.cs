using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Enum;
using MISA.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase where MISAEntity : BaseEntities
    {
        protected IBaseService _baseService;
        public BaseController(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        /// <summary>
        /// Lấy danh sách
        /// CreatedBy:LCQUYEN(10/03/2021)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetAll<MISAEntity>().ToList();
            if (entities.Count > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), entities);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), entities);
            }
        }

        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var entity = _baseService.GetObjectById<MISAEntity>(entityId);
            if (entity != null)
            {
                return StatusCode(int.Parse(MISAConst.Success), entity);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), entity);
            }
        }
        /// <summary>
        /// Thêm mới thông tin
        /// CreatedBy:LCQUYEN(10/03/2021)
        /// </summary
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var rowEffect = _baseService.Insert<MISAEntity>(entity);
            if (rowEffect.Sussess == true && rowEffect.MISACode == MISAConst.CreatedSuccess)
            {
                return StatusCode(int.Parse(MISAConst.CreatedSuccess), rowEffect);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.IsNotValid), rowEffect);
            }
        }
        /// <summary>
        /// Cập nhật thông tin
        /// CreatedBy:LCQUYEN(10/03/2021)
        /// </summary
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id,[FromBody] MISAEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(MISAEntity).Name}Id");
            if(keyProperty.PropertyType == typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if (keyProperty.PropertyType == typeof(int))
            {
                keyProperty.SetValue(entity, int.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity, id);
            }

            var rowEffect = _baseService.Update<MISAEntity>(entity);
            if (rowEffect.Sussess == true && rowEffect.MISACode == MISAConst.Success)
            {
                return StatusCode(int.Parse(MISAConst.Success), rowEffect);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.IsNotValid), rowEffect);
            }
        }
        /// <summary>
        /// Xóa thông tin
        /// CreatedBy:LCQUYEN(10/03/2021)
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var rowEffect = _baseService.Delete<MISAEntity>(entityId);
            if (rowEffect!= null && rowEffect.Sussess == true)
            {
                return StatusCode(200, rowEffect);
            }
                
            {
                return StatusCode(404, rowEffect);
            }
        }
        /// <summary>
        /// Lấy danh sách theo vị trí bắt đầu và số lượng
        /// </summary>
        /// <param name="positionStart">vị trí bắt đầu</param>
        /// <param name="offset">số lượng</param>
        /// <returns></returns>
        [HttpGet("paging")]
        public IActionResult GetDataByIndexAndOffset([FromQuery] int positionStart, [FromQuery] int offset)
        {
            var entities = _baseService.GetDataByIndexAndOffset<MISAEntity>(positionStart, offset);
            var data = entities.Data as List<MISAEntity>;
            if(data.Count > 0)
            {
                return StatusCode(int.Parse(MISAConst.Success), entities.Data);
            }
            else
            {
                return StatusCode(int.Parse(MISAConst.NoContent), entities.Data);
            }
        }
        /// <summary>
        /// Lấy số lượng bản ghi 
        /// </summary>
        /// <returns> số lượng bản ghi</returns>
        [HttpGet("numberData")]
        public int GetCountData()
        {
            var res = _baseService.GetCountData<MISAEntity>();
            return (int)res.Data;
        }
    }
}

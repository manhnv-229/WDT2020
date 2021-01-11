using Misa.BL.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Interface.IService
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy toàn bộ entity
        /// </summary>
        /// <returns>Danh sách các entity</returns>
        /// CreatedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<T> GetTs();

        /// <summary>
        /// Lấy entity bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Một entity</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        /// 
        T GetTById(string id);

        /// <summary>
        /// Thêm một thông tin khách hàng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>số khách hàng được thêm</returns>
        ServiceResult InsertT(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số lượng bản ghi được cập nhật</returns>
        /// /// CreadtedBy: Mạnh Tiến(25/12/2020)
        ServiceResult UpdateT(T entity, string id);

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        /// /// CreadtedBy: Mạnh Tiến(25/12/2020)
        ServiceResult DeleteT(string id);
        
        /// <summary>
        /// lấy bản ghi có phân trang
        /// </summary>
        /// <param name="offSet"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách các bản ghi</returns>
        /// creadtedBy: Mạnh TIến(27/12/2020)
        IEnumerable<T> GetTPaging(int offSet, int limmit);

        /// <summary>
        /// tính số bản ghi trong database
        /// </summary>
        /// <returns>Số lượng bản ghi</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        long Count();
    }
}

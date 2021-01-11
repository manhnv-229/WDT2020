using Misa.BL.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Interface.IRepository
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy toàn bộ entity
        /// </summary>
        /// <returns>Danh sách các entity</returns>
        /// CreatedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<T> GetEntitys();

        /// <summary>
        /// Lấy entity bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Một entity</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        /// 
        T GetEntityById(string id);

        /// <summary>
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Đối tượng quản lý dữ liệu sau khi thao tác Db</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        int InsertEntity(T entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số lượng bản ghi được cập nhật</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        int UpdateEntity(T entity);

        /// <summary>
        /// Xóa bản ghi theo mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Số lượng bản ghi bị xóa</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        int DeleteEntity(string code);

        /// <summary>
        /// lấy bản ghi bằng sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Danh sách các bản ghi</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<T> GEtDataBySQL(string sql);

        /// <summary>
        /// lấy bản ghi theo phân trang
        /// </summary>
        /// <param name="offSet"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách bản ghi</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<T> GetEntityPaging(int offSet, int limmit);

        /// <summary>
        /// tính tổng số bản ghi
        /// </summary>
        /// <returns>số lượng bản ghi</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        long CountEntity();
    }
}

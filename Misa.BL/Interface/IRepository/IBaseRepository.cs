using Misa.BL.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Interface.IRepository
{
    public interface IBaseRepository<T>
    {
        #region get entity
        /// <summary>
        /// lấy bản ghi bằng sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Danh sách các bản ghi</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<T> GEtDataBySQL(string sql);

        /// <summary>
        /// lấy danh sách bản ghi theo fielName(option)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <param name="fieldNames"></param>
        /// <param name="values"></param>
        /// <returns>danh sách các bản ghi</returns>
        /// createdBy: Manh Tien (5/2/2021)
        IEnumerable<T> GetData(long page, long limmit, List<string> fieldNames = null, List<string> values = null);
        #endregion

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
        /// tính tổng số bản ghi
        /// </summary>
        /// <returns>số lượng bản ghi</returns>
        /// CreadtedBy: Mạnh Tiến(5/2/2020)
        long CountEntity(List<string> fieldNames = null, List<string> values = null);
    }
}

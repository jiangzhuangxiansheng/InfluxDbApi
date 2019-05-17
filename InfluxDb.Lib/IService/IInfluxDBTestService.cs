using InfluxDb.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfluxDb.Lib.IService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInfluxDBTestService
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbTable"></param>
        /// <returns></returns>
        Task<IList<IList<object>>> GetInfluxDb(string dbName, string dbTable, string sql);
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns></returns>
        Task<InfluxResultModel> AddInfluxDb(AddModel addModel);
    }
}

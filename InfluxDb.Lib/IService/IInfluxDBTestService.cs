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
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbTable"></param>
        /// <returns></returns>
        Task<IList<IList<object>>> GetInfluxDb(string dbName, string dbTable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbTable"></param>
        /// <returns></returns>
        Task<InfluxResultModel> AddInfluxDb(string dbName, string dbTable);
    }
}

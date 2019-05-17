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
    public interface IOperationService
    {
        /// <summary>
        /// GET
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbTable"></param>
        Task<IList<IList<object>>> GetData(string dbName, string dbTable, string sql);
        /// <summary>
        /// ADD
        /// </summary>
        Task<InfluxResultModel> AddData(AddModel addModel);
    }
}

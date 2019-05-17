using InfluxDb.Lib.IService;
using InfluxDb.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfluxDb.Lib.Service
{
    public class InfluxDBTestService : IInfluxDBTestService
    {
        private readonly IOperationService operationHelp;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationHelp"></param>
        public InfluxDBTestService(IOperationService operationHelp)
        {
            this.operationHelp = operationHelp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<IList<object>>> GetInfluxDb(string dbName, string dbTable,string sql)
        {
            var rest = await operationHelp.GetData(dbName, dbTable, sql);
            return rest;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns></returns>
        public async Task<InfluxResultModel> AddInfluxDb(AddModel addModel)
        {
            var rest = await operationHelp.AddData(addModel);
            return rest;
        }
    }
}

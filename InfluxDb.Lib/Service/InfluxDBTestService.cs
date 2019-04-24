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
        public async Task<IList<IList<object>>> GetInfluxDb(string dbName, string dbTable)
        {
            var rest = await operationHelp.GetData(dbName, dbTable);
            return rest;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbTable"></param>
        /// <returns></returns>
        public async Task<InfluxResultModel> AddInfluxDb(string dbName, string dbTable)
        {
            var rest = await operationHelp.AddData(dbName, dbTable);
            return rest;
        }

        //public string GetInfluxDb(string dbName, string sql)
        //{
        //    var rest = operationHelp.Query(dbName, sql);
        //    return rest;
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dbName"></param>
        ///// <param name="dbTable"></param>
        ///// <returns></returns>
        //public string AddInfluxDb(string dbName, string sql)
        //{
        //    var rest = operationHelp.Write(dbName, sql);
        //    return rest;
        //}
    }
}

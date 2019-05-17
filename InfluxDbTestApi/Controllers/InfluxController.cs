using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxDb.Lib.Help;
using InfluxDb.Lib.IService;
using InfluxDb.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace InfluxDbTestApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Influx")]
    [Produces("application/json")]
    [ApiController]
    public class InfluxController : ControllerBase
    {
        private readonly IInfluxDBTestService influxDBTest;
        private readonly ILogger debugInfo;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="influxDBTest"></param>
        public InfluxController(IInfluxDBTestService influxDBTest)
        {
            this.influxDBTest = influxDBTest;
            debugInfo = LogManager.GetLogger("debugInfo");
        }

        /// <summary>
        /// 获取表参数
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbTable"></param>
        /// <param name="sql">必须用limit语句分页，数据量大</param>
        /// <returns></returns>
        [Route("GetInflux"), HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetInflux([FromQuery] string dbName, string dbTable,string sql)
        {
            var id = await influxDBTest.GetInfluxDb(dbName, dbTable,sql);
            return Ok(id);
        }

        /// <summary>
        /// 添加表信息
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns></returns>
        [Route("AddInflux"), HttpPost]
        public async Task<IActionResult> AddInflux([FromBody] AddModel addModel)
        {
            try
            {
                debugInfo.Debug(addModel.ToJsonString());
                if (addModel == null)
                    throw new Exception("传入数据是空！");
                var id = await influxDBTest.AddInfluxDb(addModel);
                return Ok(id);
            }
            catch (Exception ex)
            {
                debugInfo.Debug(ex.Message);
                throw ex;
            }
            
        }
    }
}

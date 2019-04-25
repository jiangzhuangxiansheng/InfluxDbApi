using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfluxDb.Lib.IService;
using InfluxDb.Lib.Models;
using Microsoft.AspNetCore.Mvc;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="influxDBTest"></param>
        public InfluxController(IInfluxDBTestService influxDBTest)
        {
            this.influxDBTest = influxDBTest;
        }

        /// <summary>
        /// 获取表参数
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbTable"></param>
        /// <returns></returns>
        [Route("GetInflux"), HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetInflux([FromQuery] string dbName, string dbTable)
        {
            var id = await influxDBTest.GetInfluxDb(dbName, dbTable);
            return Ok(id);
        }

        /// <summary>
        /// 添加表信息
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbTable"></param>
        /// <returns></returns>
        [Route("AddInflux"), HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddInflux([FromBody] AddModel addModel)
        {
            if (addModel == null)
                throw new Exception("传入数据是空！");
            var id = await influxDBTest.AddInfluxDb(addModel);
            return Ok(id);
        }
    }
}

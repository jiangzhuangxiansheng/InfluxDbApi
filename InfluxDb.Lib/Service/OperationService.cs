using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using InfluxData.Net.InfluxDb.Models;
using InfluxDb.Lib.Help;
using InfluxDb.Lib.IService;
using InfluxDb.Lib.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluxDb.Lib.Service
{
    /// <summary>
    /// 操作InfluxDb方法
    /// </summary>
    public class OperationService : IOperationService
    {
       
        //Influx配置
        private readonly InfluxDbModel influx;
        private readonly InfluxDbClient dbClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="influxDb"></param>
        public OperationService(IOptions<InfluxDbModel> influxDb, InfluxDbClient dbClient)
        {
            influx = influxDb.Value;
            this.dbClient = dbClient;
            //clientDb = new InfluxDbClient(influx.InfluxUrl, influx.InfluxUser, influx.InfluxPwd, InfluxDbVersion.Latest);
        }

        /// <summary>
        /// 从InfluxDB中读取数据
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="dbTable">数据库表名称</param>
        public async Task<IList<IList<object>>> GetData(string dbName, string dbTable)
        {
            try
            {
                if (string.IsNullOrEmpty(dbName) && string.IsNullOrEmpty(dbTable))
                    throw new Exception("Error：数据库名称或者表名称是空！");
                //传入查询命令，支持多条
                var queries = new[]
                {
                    $"SELECT * FROM {dbTable} WHERE region='us-west'"
                };
                //从指定库中查询数据
                var response = await dbClient.Client.QueryAsync(queries, dbName);
                //得到Serie集合对象（返回执行多个查询的结果）
                var series = response.ToList();
                //取出第一条命令的查询结果，是一个集合
                var list = series[0].Values;
                //从集合中取出第一条数据
                //var info_model = list.FirstOrDefault();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 往InfluxDB中写入数据
        /// </summary>
        public async Task<InfluxResultModel> AddData(AddModel addModel)
        {
            try
            {
                //基于InfluxData.Net.InfluxDb.Models.Point实体准备数据
                var point_model = new Point()
                {
                    Name = addModel.Db_Table,
                    Tags = new Dictionary<string, object>()
                    {
                        { "Gateway_Id", addModel.Gateway_id},
                        { "Keep_Alive",addModel.Keep_alive.ToString()},
                        { "Device_Id",addModel.Device_id}
                    },
                    Fields = new Dictionary<string, object>()
                    {
                        { "PublishTime", addModel.Ts},
                        { "device_type",addModel.Device_type},
                        { "Data",addModel.Data.ToJsonString()}
                    },
                    Timestamp = DateTime.UtcNow
                };

                //从指定库中写入数据，支持传入多个对象的集合
                var response = await dbClient.Client.WriteAsync(point_model, addModel.Db_Name);

                InfluxResultModel result = new InfluxResultModel()
                {
                    StatusCode = response.StatusCode.ToString(),
                    Body = response.Body,
                    Success = response.Success
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

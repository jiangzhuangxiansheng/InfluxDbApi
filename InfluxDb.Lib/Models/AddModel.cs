using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.Lib.Models
{
    /// <summary>
    /// 添加采集数据
    /// </summary>
    public class AddModel : Db_Model
    {
        [JsonProperty("ts")]
        /// <summary>
        /// 发布时间
        /// </summary>
        public string Ts { get; set; }
        [JsonProperty("gateway_id")]
        /// <summary>
        /// id
        /// </summary>
        public string Gateway_id { get; set; }
        [JsonProperty("keep_alive")]
        /// <summary>
        /// 是否启动
        /// </summary>
        public bool Keep_alive { get; set; }
        [JsonProperty("device_id")]
        /// <summary>
        /// id
        /// </summary>
        public string Device_id { get; set; }
        [JsonProperty("device_type")]
        /// <summary>
        /// 
        /// </summary>
        public string Device_type { get; set; }
        [JsonProperty("data")]
        /// <summary>
        /// 
        /// </summary>
        public List<DataModel> Data { get; set; }
    }
    public class DataModel
    {
        [JsonProperty("key")]
        /// <summary>
        /// 主键
        /// </summary>
        public string Key { get; set; }

        [JsonProperty("number")]
        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }
        [JsonProperty("value_type")]
        /// <summary>
        /// 类型
        /// </summary>
        public string Value_type { get; set; }
        [JsonProperty("value")]
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}

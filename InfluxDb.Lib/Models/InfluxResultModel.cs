using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.Lib.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class InfluxResultModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; set; }
    }
    public class ResultModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Statement_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Series { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Serie
    {
        public string Name { get; set; }
        public string Columns { get; set; }
        public string Values { get; set; }
    }
    public class Colume
    {
        public string Time { get; set; }
        public string Value { get; set; }
    }
}

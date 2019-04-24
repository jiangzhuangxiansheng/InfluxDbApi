using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.Lib.Models
{
    /// <summary>
    /// InfluxDb
    /// </summary>
    public class InfluxDbModel
    {
        /// <summary>
        /// Url地址
        /// </summary>
        public string InfluxUrl { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string InfluxUser { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string InfluxPwd { get; set; }
    }
}

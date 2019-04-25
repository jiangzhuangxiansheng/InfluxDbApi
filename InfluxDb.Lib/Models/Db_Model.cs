using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.Lib.Models
{
    /// <summary>
    /// 
    /// </summary>
   public class Db_Model
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Db_Name { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        public string Db_Table { get; set; }
    }
}

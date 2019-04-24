﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.Lib.Help
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeExtentions
    {
        /// <summary>
        /// 将当前时间转换成unix时间戳形式
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(this DateTime datetime)
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
    }
}

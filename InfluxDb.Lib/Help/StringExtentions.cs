using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfluxDb.Lib.Help
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonString(this object obj)
        {
            if (obj == null)
            {
                return "{}";
            }
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { DateFormatString = "yyyy/MM/dd HH:mm:ss", MaxDepth = 4, NullValueHandling = NullValueHandling.Include });
        }
    }
}

using ORMDemo.DBFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ORMDemo.Mapping
{
    public static class DBFilterExtend
    {
        public static IEnumerable<PropertyInfo> GetPropertiesWithNoKey(this Type type) 
        {
            return type.GetProperties().Where(p => !p.IsDefined(typeof(KeyAttribute), true));
        }
    }
}

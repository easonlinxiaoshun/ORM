using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ORMDemo.Mapping
{
    public static class DBMappingExtend
    {
        public static string GetBaseMappingName<T>(this T t) where T:MemberInfo
        {
            if (t.IsDefined(typeof(BaseAttribute), true))
            {
                var attribute = t.GetCustomAttribute<BaseAttribute>();
                return attribute.GetMappingName();
            }
            else
            {
                return t.Name;
            }
        }

        public static string GetMappingName(this Type type) {
            if (type.IsDefined(typeof(DBAttribute), true))
            {
                var attribute = type.GetCustomAttribute<DBAttribute>();
                return attribute.GetMappingName();
            }
            else {
                return type.Name;
            }
        }
    }
}

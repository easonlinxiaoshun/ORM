using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace ORMDemo.Validata
{
    public static class DataValiExtend
    {
        public static bool ValiDataModel<T>(this T t) 
        {
            Type type = typeof(T);
            foreach (var item in type.GetProperties()) {
                //if (item.IsDefined(typeof(RequiredAttribute),true)) {
                //    object value = item.GetValue(t);
                //    var attribute = item.GetCustomAttribute<RequiredAttribute>();
                //    if (!attribute.Validate(value)) {
                //        return false;
                //    }
                //    //if (value==null||string.IsNullOrWhiteSpace(value.ToString())) {
                //    //    return false;
                //    //}
                //}

                //if (item.IsDefined(typeof(LengthAttribute), true))
                //{
                //    object value = item.GetValue(t);
                //    var attribute = item.GetCustomAttribute<LengthAttribute>();
                //    if (!attribute.Validate(value))
                //    {
                //        return false;
                //    }
                //    //if (value == null || string.IsNullOrWhiteSpace(value.ToString())||value.ToString().Length<attribute._iMin|| value.ToString().Length >=attribute._iMax)
                //    //{
                //    //    return false;
                //    //}
                //}

                if (item.IsDefined(typeof(ValiDataBaseAttribute), true)) {
                    object value = item.GetValue(t);
                    var attributes = item.GetCustomAttributes<ValiDataBaseAttribute>();
                    foreach (var attribute in attributes) {
                        if (!attribute.Validate(value))
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }
    }
}

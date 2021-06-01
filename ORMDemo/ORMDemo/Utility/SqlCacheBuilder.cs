using ORMDemo.Mapping;
using ORMDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Utility
{
    /// <summary>
    /// 负责生成sql，缓存重用
    /// </summary>
    public class SqlCacheBuilder<T> where T:BaseModel,  new()
    {
        private static string _InsertSql = null;
        private static string _FindSql = null;
        static SqlCacheBuilder()
        {
            {
                Type type = typeof(T);
                string colunmString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetBaseMappingName() }]"));
                _FindSql = $"SELECT {colunmString} from {type.GetBaseMappingName()} Where ID= @Id";


            }


            {
                Type type = typeof(T);
                string columnStr = string.Join(",", type.GetPropertiesWithNoKey().Select(p => p.GetBaseMappingName()));
                
                string valueStr = string.Join(",", type.GetPropertiesWithNoKey().Select(p => $"@{p.GetBaseMappingName()}"));

                _InsertSql = $"Insert Into {type.GetBaseMappingName()} ({columnStr}) Values ({valueStr})";

            }
        }

        public static string GetSql(SqlCacheBuilderType sqlCacheBuilderType) {
            switch (sqlCacheBuilderType)
            {
                case SqlCacheBuilderType.FindOne:
                    return _FindSql;
                case SqlCacheBuilderType.Insert:
                    return _InsertSql;
                default:
                    throw new Exception("Unknown SqlCacheBuilderType");
            }
            
        }

        
    }

    public enum SqlCacheBuilderType
    {
        FindOne,
        Insert
    }

    public class CustomCache 
    {
        private static Dictionary<string, string> CustomCacheDictionary = new Dictionary<string, string>();

        public static void Add(string key,string value) 
        {
            CustomCacheDictionary.Add(key, value);
        }

        public static string Get(string key)
        {
           return CustomCacheDictionary[key];
        }
    }
}

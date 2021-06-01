using ORMDemo.Mapping;
using ORMDemo.Model;
using ORMDemo.Validata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Utility
{
    public class SqlHelper
    {
        public static string ConStr { get; set; }

        public T Find<T>(int id) where T: BaseModel,new()
        {
            Type type = typeof(T);
            //string colunmString = string.Join(",",type.GetProperties().Select(p=>$"[{p.GetBaseMappingName() }]"));
            //string sqlstring = $"SELECT {colunmString} from {type.GetBaseMappingName()} Where ID= {id}";
            string sqlstring = SqlCacheBuilder<T>.GetSql(SqlCacheBuilderType.FindOne);
            SqlParameter[] parameters = new SqlParameter[] { 
            new SqlParameter("@Id",id)
            };
            using (SqlConnection conn=new SqlConnection(ConStr)) {
                SqlCommand command = new SqlCommand(sqlstring, conn);
                command.Parameters.AddRange(parameters);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    T t = Activator.CreateInstance<T>();
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(t, reader[prop.GetBaseMappingName()] is DBNull?null: reader[prop.GetBaseMappingName()]);
                    }
                    return t;
                }
                else {
                    return default;
                }
            }
        }

        public bool Insert<T>(T t) where T : BaseModel ,new()
        {
            Type type = typeof(T);
            //string columnStr = string.Join(",",type.GetPropertiesWithNoKey().Select(p=>p.GetBaseMappingName()));
            ////string valueStr = string.Join(",",type.GetPropertiesWithNoKey().Select(p=>$"'{p.GetValue(t)}'"));

            //string valueStr = string.Join(",", type.GetPropertiesWithNoKey().Select(p => $"@{p.GetBaseMappingName()}"));

            //string sql = $"Insert Into {type.GetBaseMappingName()} ({columnStr}) Values ({valueStr})";

            string sql = SqlCacheBuilder<T>.GetSql(SqlCacheBuilderType.Insert);

            var parameter = type.GetProperties().Select(p => new SqlParameter($"@{p.GetBaseMappingName()}", p.GetValue(t) ?? DBNull.Value)).ToArray();//若为空则使用DBNull,否则数据库无法识别

            using (SqlConnection conn=new SqlConnection(ConStr)) {
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddRange(parameter);
                conn.Open();
                int iresult = cmd.ExecuteNonQuery();
                return iresult==1;
            }
        }

        public bool Update<T>(T t) where T : BaseModel, new()
        {
            if (!t.ValiDataModel()) {
                throw new Exception("数据校验失败");
            }
            Type type = typeof(T);
            string columnStr = string.Join(",",type.GetPropertiesWithNoKey().Select(p=>$"{p.GetBaseMappingName()}=@{p.GetBaseMappingName()}"));
            string sql = $"Update {type.GetBaseMappingName()} SET {columnStr} Where Id=@Id";
            var parameter = type.GetPropertiesWithNoKey().Select(p =>new SqlParameter($"@{p.GetBaseMappingName()}",p.GetValue(t))).Append(new SqlParameter("@Id",t.Id)).ToArray();
            using (SqlConnection conn=new SqlConnection(ConStr)) {
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddRange(parameter);
                conn.Open();
                return 1 == cmd.ExecuteNonQuery();
            }

        }

        public bool Delete<T>(T t) where T:BaseModel
        {
            Type type = typeof(T);
            string sql = $"Delete From {type.GetBaseMappingName()} Where Id=@Id";
            SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@Id",t.Id) };
            using (SqlConnection conn=new SqlConnection(ConStr)) {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(sqlParameter);
                conn.Open();
                return 1 == cmd.ExecuteNonQuery();
            }
        }
    }
}

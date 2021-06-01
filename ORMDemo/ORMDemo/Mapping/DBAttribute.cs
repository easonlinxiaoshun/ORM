using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Mapping
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DBAttribute: BaseAttribute
    {
        //private string _TableName = null;
        public DBAttribute(string tableName):base(tableName)
        {
            //this._TableName = tableName;
        }

        //public string GetMappingName() {
        //    return this._TableName;
        //}
    }
}

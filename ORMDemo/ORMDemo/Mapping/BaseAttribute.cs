using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Mapping
{
    public class BaseAttribute:Attribute
    {
        private string _MappingName = null;
        public BaseAttribute(string mappingName)
        {
            this._MappingName = mappingName;
        }

        public string GetMappingName()
        {
            return this._MappingName;
        }
    }
}

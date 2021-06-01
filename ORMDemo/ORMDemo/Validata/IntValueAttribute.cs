using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Validata
{
    /// <summary>
    /// int规定范围
    /// </summary>
    public class IntValueAttribute : ValiDataBaseAttribute
    {
        private int[] _Values = null;
        public IntValueAttribute(params int[] values)
        {
            this._Values = values;
        }

        public override bool Validate(object value)
        {
            return value != null && !string.IsNullOrWhiteSpace(value.ToString()) && int.TryParse(value.ToString(), out int ivalue) && this._Values != null && this._Values.Contains(ivalue);
        }
    }
}

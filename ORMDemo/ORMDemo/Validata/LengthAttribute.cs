using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Validata
{
    /// <summary>
    /// 要求长度
    /// </summary>
    public class LengthAttribute: ValiDataBaseAttribute
    {
        public int _iMin = 0;
        public int _iMax = 0;
        public LengthAttribute(int min,int max) 
        {
            this._iMin = min;
            this._iMax = max;
        }

        public override bool Validate(object value)
        {
            return value != null && !string.IsNullOrWhiteSpace(value.ToString()) && value.ToString().Length >= this._iMin && value.ToString().Length < this._iMax;
        }
    }
}

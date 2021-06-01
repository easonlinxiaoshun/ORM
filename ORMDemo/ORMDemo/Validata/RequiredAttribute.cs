using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Validata
{
    /// <summary>
    /// 要求非空
    /// </summary>
    public class RequiredAttribute: ValiDataBaseAttribute
    {
        public override bool Validate(object value) {
            return value != null && !string.IsNullOrWhiteSpace(value.ToString());
        }
    }
}

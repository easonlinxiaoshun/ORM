using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Validata
{
    public abstract class ValiDataBaseAttribute : Attribute
    {
        public abstract bool Validate(object value);
    }
}

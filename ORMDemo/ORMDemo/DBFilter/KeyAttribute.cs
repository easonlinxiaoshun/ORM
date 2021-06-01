using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.DBFilter
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyAttribute:Attribute
    {
    }
}

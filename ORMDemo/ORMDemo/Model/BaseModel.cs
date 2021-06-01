using ORMDemo.DBFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Model
{
    public class BaseModel
    {
        [KeyAttribute]
        public int Id { get; set; }
    }
}

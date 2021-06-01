using ORMDemo.DBFilter;
using ORMDemo.Mapping;
using ORMDemo.Validata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMDemo.Model
{
    [DBAttribute("Products")]
    public class Products: BaseModel
    {
        [RequiredAttribute]
        [LengthAttribute(2,10)]
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        [IntValueAttribute(100,120,130)]
        public decimal Price { get; set; }
        public decimal OrgPrice { get; set; }
        public string Decoration { get; set; }
        public string Size { get; set; }
        public double ClickTimes { get; set; }
        public double SaleTimes { get; set; }
        public bool IsDel { get; set; }
    }
}

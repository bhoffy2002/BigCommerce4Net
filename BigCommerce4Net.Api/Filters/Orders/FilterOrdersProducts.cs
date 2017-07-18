using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigCommerce4Net.Api
{ 
    public class FilterOrdersProducts : Filter, IFilter
    {
        public int OrderID { get; set; }
    }
}

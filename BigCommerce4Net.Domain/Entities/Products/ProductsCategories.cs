using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BigCommerce4Net.Domain
{
    public class ProductsCategories : EntityBase
    {
        /// <summary>
        /// The unique ID of the product level rule. 
        /// 
        /// int
        /// </summary>
        [JsonProperty("Category_id")]
        public virtual int CategoryID { get; set; }

        /// <summary>
        /// The ID of the product which the rule applies to. 
        /// 
        /// int
        /// </summary>
        [JsonProperty("product_id")]
        public virtual int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}

#region License
//   Copyright 2013 Ken Worst - R.C. Worst & Company Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

using Newtonsoft.Json;

namespace BigCommerce4Net.Domain.Entities.V2.Orders
{
    public class OrdersShipmentItem : EntityBase
    {
        /// <summary>
        /// The ID of the Order Product the item is associated with.
        /// </summary>
        [JsonProperty("order_product_id")]
        public virtual int OrderProductId { get; set; }

        /// <summary>
        /// The ID of the Product the item is associated with.
        /// </summary>
        [JsonProperty("product_id")]
        public virtual int ProductId { get; set; }

        /// <summary>
        /// The quantity of the item in the shipment.
        /// </summary>
        [JsonProperty("quantity")]
        public virtual int Quantity { get; set; }
    }
}
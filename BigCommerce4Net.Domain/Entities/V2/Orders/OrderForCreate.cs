using System;
using System.Collections.Generic;
using BigCommerce4Net.Domain.ExtensionMethods;
using Newtonsoft.Json;

namespace BigCommerce4Net.Domain.Entities.V2.Orders
{
    public class OrderForCreate
    {
        public OrderForCreate()
        {
            Products = new List<OrdersProductsForCreate>();
            //Shipments = new List<OrdersShipment>();
            //ShippingAddresses = new List<OrdersShippingAddress>();
            //Coupons = new List<OrdersCoupon>();
        }


        /// <summary>
        /// The ID of the customer that placed the order or 0 if it was a guest order.
        /// </summary>
        [JsonProperty("customer_id")]
        public virtual int CustomerId { get; set; }

        /// <summary>
        /// The date the order was placed. If not supplied, the current date will be used. Please note that orders processed 
        /// by live online payment gateways first arrive in the orders data with an "Incomplete" status and are then updated 
        /// (see the date_modified field) with final payment information. If your application relies on the arrival of new 
        /// orders you may need to check both date_created and status fields (or status_id).
        /// </summary>
        [JsonIgnore]
        public virtual DateTime? DateCreated { get; set; }

        [JsonProperty("date_created")]
        public virtual string DateCreatedUT
        {
            get
            {
                return DateCreated.DateTimeToString();
            }
            set
            {
                DateCreated = value.StringToDateTime();
            }
        }
        
        
        /// <summary>
        /// The subtotal of the order excluding tax.
        /// </summary>
        [JsonProperty("subtotal_ex_tax")]
        public virtual decimal SubtotalExcludingTax { get; set; }

        /// <summary>
        /// The subtotal of the order including tax.
        /// </summary>
        [JsonProperty("subtotal_inc_tax")]
        public virtual decimal SubtotalIncludingTax { get; set; }


        /// <summary>
        /// The base shipping cost of the order. The base shipping cost is the 
        /// sum of all of the shipping costs minus any discount amounts to the 
        /// shipping costs. It may be inc or ex tax depending on the "Prices Entered With Tax?" 
        /// tax setting.The base shipping * cost is the sum of all of the base shipping costs on 
        /// each address. A * base shipping cost is a price entered by the store owner, either 
        /// inc or * ex tax.
        /// </summary>
        [JsonProperty("base_shipping_cost")]
        public virtual decimal BaseShippingCost { get; set; }

        /// <summary>
        /// The total shipping cost of the order excluding tax.
        /// </summary>
        [JsonProperty("shipping_cost_ex_tax")]
        public virtual decimal ShippingCostExcludingTax { get; set; }

        /// <summary>
        /// The total shipping cost of the order including tax.
        /// </summary>
        [JsonProperty("shipping_cost_inc_tax")]
        public virtual decimal ShippingCostIncludingTax { get; set; }



        /// <summary>
        /// The base handling cost of the order. The base handling cost is the 
        /// sum of the all the handling costs. It may be inc or ex tax depending 
        /// on the "Prices Entered With Tax?" tax setting.
        /// </summary>
        [JsonProperty("base_handling_cost")]
        public virtual decimal BaseHandlingCost { get; set; }

        /// <summary>
        /// The handling cost of the order excluding tax.
        /// </summary>
        [JsonProperty("handling_cost_ex_tax")]
        public virtual decimal HandlingCostExcludingTax { get; set; }

        /// <summary>
        /// The handing cost of the order including tax.
        /// </summary>
        [JsonProperty("handling_cost_inc_tax")]
        public virtual decimal HandlingCostIncludingTax { get; set; }

        /// <summary>
        /// The base wrapping cost of the order. The base wrapping cost is the sum 
        /// of all the wrapping costs on the items. It may be inc or ex tax depending 
        /// on the "Prices Entered With Tax?" tax setting.
        /// </summary>
        [JsonProperty("base_wrapping_cost")]
        public virtual decimal BaseWrappingCost { get; set; }

        /// <summary>
        /// The wrapping cost of the order including tax.
        /// </summary>
        [JsonProperty("wrapping_cost_ex_tax")]
        public virtual decimal WrappingCostExcludingTax { get; set; }

        /// <summary>
        /// The wrapping cost of the order excluding tax.
        /// </summary>
        [JsonProperty("wrapping_cost_inc_tax")]
        public virtual decimal WrappingCostIncludingTax { get; set; }


        /// <summary>
        /// The total of the order excluding tax.
        /// </summary>
        [JsonProperty("total_ex_tax")]
        public virtual decimal TotalExcludingTax { get; set; }

        /// <summary>
        /// The total of the order including tax.
        /// </summary>
        [JsonProperty("total_inc_tax")]
        public virtual decimal TotalIncludingTax { get; set; }

        /// <summary>
        /// The status of the order. A list of available statuses can be retrieved 
        /// from Order Statuses
        /// </summary>
        [JsonProperty("status_id")]
        public virtual int StatusId { get; set; }

        /// <summary>
        /// The total quantity of the items (sum of products * quantity) in the order.
        /// </summary>
        [JsonProperty("items_total")]
        public virtual int ItemsTotal { get; set; }

        /// <summary>
        /// The quantity of items that have been shipped.
        /// </summary>
        [JsonProperty("items_shipped")]
        public virtual int ItemsShipped { get; set; }

        /// <summary>
        /// The payment method used for the order.
        /// 
        /// [string(100)]
        /// </summary>
        [JsonProperty("payment_method")]
        public virtual string PaymentMethod { get; set; }

        /// <summary>
        /// The ID or reference number of a payment from the payment provider/gateway.
        /// 
        /// [string(255)]
        /// </summary>
        [JsonProperty("payment_provider_id")]
        public virtual string PaymentProviderId { get; set; }
        
  
        ///// <summary>
        ///// The amount that that has been refunded for the order.
        ///// </summary>
        //[JsonProperty("refunded_amount")]
        //public virtual decimal RefundedAmount { get; set; }

        /// <summary>
        /// Indicates if the order contains purely digital delivery products.
        /// </summary>
        [JsonProperty("order_is_digital")]
        public virtual bool OrderIsDigital { get; set; }

        ///// <summary>
        ///// Staff notes on the order.
        ///// </summary>
        //[JsonProperty("staff_notes")]
        //public virtual string StaffNotes { get; set; }

        ///// <summary>
        ///// An order message left by the customer when placing the order.
        ///// </summary>
        //[JsonProperty("customer_message")]
        //public virtual string CustomerMessage { get; set; }

        /// <summary>
        /// The total discounts applied to the order, excluding coupons.
        /// </summary>
        [JsonProperty("discount_amount")]
        public virtual decimal DiscountAmount { get; set; }


        /// <summary>
        /// The address that the order is billed to.  
        /// Billing Address section below for a definition of this object. 
        /// 
        /// See https://developer.bigcommerce.com/display/API/Orders
        /// </summary>
        [JsonProperty("billing_address")]
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// The address (or addresses if multi-address shipping was used) that 
        /// the products were shipped to. See the Shipping Addresses resource for details.
        /// 
        /// NB. Purely digital delivery orders will not have any shipping addresses.
        /// 
        /// See https://developer.bigcommerce.com/display/API/Addresses
        /// </summary>
        
        //[JsonProperty("shipping_addresses")]
        //public virtual Resource ResourceShippingAddresses { get; set; }

        /// <summary>
        /// The list of products purchased in the order. See the Products sub-resource 
        /// for a definition of this object. 
        /// 
        /// See https://developer.bigcommerce.com/display/API/Order+Products
        /// </summary>
        //[JsonProperty("products")]
        //public virtual Resource ResourceProducts { get; set; }


        //[JsonIgnore]
        //public virtual Customer Customer { get; set; }

        //[JsonIgnore]
        //public virtual IList<OrdersCoupon> Coupons { get; set; }

        [JsonProperty("products")]
        public virtual IList<OrdersProductsForCreate> Products { get; set; }


        //[JsonIgnore]
        //public virtual IList<OrdersShippingAddress> ShippingAddresses { get; set; }

        public class OrdersProductsForCreate
        {
            public OrdersProductsForCreate()
            {
                ProductOptions = new List<OrdersProductsOptionForOrderCreate>();
            }
        
            
            /// <summary>
            /// The ID of the actual product this order product refers to.
            /// </summary>
            [JsonProperty("product_id")]
            public virtual int ProductId { get; set; }

            /// <summary>
            /// The quantity of the product that was purchased.
            /// </summary>
            [JsonProperty("quantity")]
            public virtual int Quantity { get; set; }

            /// <summary>
            /// The price of the product excluding tax.
            /// 
            /// [decimal(20,4)]
            /// </summary>
            [JsonProperty("price_ex_tax")]
            public virtual decimal PriceExcludingTax { get; set; }

            /// <summary>
            /// The price of the product include tax.
            /// 
            /// [decimal(20,4)]
            /// </summary>
            [JsonProperty("price_inc_tax")]
            public virtual decimal PriceIncludingTax { get; set; }

            [JsonProperty("product_options")]
            public List<OrdersProductsOptionForOrderCreate> ProductOptions { get; set; }




            public class OrdersProductsOptionForOrderCreate //: EntityBase
            {
                /// <summary>
                /// The ID of the order product option applied to the order product.
                /// </summary>
                [JsonProperty("id")]
                public virtual int Id { get; set; }

                

                /// <summary>
                /// The customer supplied value for this option. The value depends on the type 
                /// of Product Option. See the Product Option supplemental document for more details.  
                /// </summary>
                [JsonProperty("value")]
                public virtual string Value { get; set; }

                
            }

        }
    }
}

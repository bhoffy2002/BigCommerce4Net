using System;
using System.Collections.Generic;
using BigCommerce4Net.Api;
using BigCommerce4Net.Domain;

namespace BigCommerce4Net.V3.Catalog
{
	public class ProductFilter : Filter
	{
		/// <summary>
		/// Filter items by id.
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Filter items by name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Filter items by sku.
		/// </summary>
		public string Sku { get; set; }

		/// <summary>
		/// Filter items by upc.
		/// </summary>
		public string Upc { get; set; }

		/// <summary>
		/// Filter items by price.
		/// </summary>
		public decimal? Price { get; set; }

		/// <summary>
		/// Filter items by weight.
		/// </summary>
		public decimal? Weight { get; set; }

		/// <summary>
		/// Filter items by condition.
		/// </summary>
		public ProductsCondition? Condition { get; set; }

		/// <summary>
		/// Filter items by brand_id.
		/// </summary>
		public int? BrandId { get; set; }

		/// <summary>
		/// Filter items by date_modified.
		/// </summary>
		public DateTime? DateModified { get; set; }

		/// <summary>
		/// Filter items by date_last_imported.
		/// </summary>
		public DateTime? DateLastImported { get; set; }

		/// <summary>
		/// Filter items by is_visible.
		/// </summary>
		public bool? IsVisible { get; set; }

		/// <summary>
		/// Filter items by is_featured.
		/// </summary>
		public bool? IsFeatured { get; set; }

		/// <summary>
		/// Filter items by is_free_shipping.
		/// </summary>
		public bool? IsFreeShipping { get; set; }

		/// <summary>
		/// Filter items by inventory_level.
		/// </summary>
		public int? InventoryLevel { get; set; }

		/// <summary>
		/// Filter items by inventory_low; values: 1, 0.
		/// </summary>
		public bool? InventoryLow { get; set; }

		/// <summary>
		/// Filter items by out_of_stock. To enable the filter, pass out_of_stock=1.
		/// </summary>
		public bool? OutOfStock { get; set; }

		/// <summary>
		/// Filter items by total_sold.
		/// </summary>
		public int? TotalSold { get; set; }

		/// <summary>
		/// Filter items by type: physical or digital.
		/// </summary>
		public ProductsType? Type { get; set; }

		/// <summary>
		/// Filter items by categories. (NOTE: To ensure that your request will retrieve products that are also cross-listed in additional categories beyond the categories you’ve specified, use the syntax: categories:in=.)
		/// </summary>
		public int[] Categories { get; set; }

		/// <summary>
		/// Filter items by keywords found in the name, description, or sku fields, or in the brand name.
		/// </summary>
		public string Keyword { get; set; }

		/// <summary>
		/// Set context for a product search.
		/// </summary>
		public string KeywordContext { get; set; }

		/// <summary>
		/// Filter items by status.
		/// </summary>
		public int? Status { get; set; }

		

		/// <summary>
		/// Filter items by availability. Acceptable values are: available, disabled, preorder.
		/// </summary>
		public string Availability { get; set; }

		/// <summary>
		/// The ID of the Price List.
		/// </summary>
		public int? PriceListId { get; set; }


		public override string Sort { get; set; }
	}
}

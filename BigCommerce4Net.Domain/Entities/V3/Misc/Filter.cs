using System;

namespace BigCommerce4Net.Domain.V3.Misc
{
	public abstract class Filter : IFilter
	{
		protected const string RFC2822_DATE_FORMAT = "{0:ddd, dd MMM yyyy HH:mm:ss} GMT";

		/// <summary>
		/// How many results you'd like returned by providing a 
		/// limit parameter, which has a maximum of 250
		/// </summary>
		public int? Limit { get; set; }

		/// <summary>
		/// To retrieve a particular page of results, you can 
		/// provide a page parameter, where 1 is the first page
		/// </summary>
		public int? Page { get; set; }

		/// <summary>
		/// GET Operations Only
		/// 
		/// If supplied, then only resources modified since the specified date 
		/// will be returned. If there are no modified objects, then a 304 Not 
		/// Modified response will be sent. Please refer to the individual resource 
		/// pages for support for this header.
		/// </summary>
		public DateTime? IfModifiedSince { get; set; }

		/// <summary>
		/// Sub-resources to include on a product, in a comma-separated list. Valid expansions currently include variants, images, custom_fields, and bulk_pricing_rules.
		/// </summary>
		public string Include { get; set; }


		/// <summary>
		/// Fields to include, in a comma-separated list. The ID and the specified fields will be returned.
		/// </summary>
		public string IncludeFields { get; set; }

		/// <summary>
		/// Fields to exclude, in a comma-separated list. The specified fields will be excluded from a response. The ID cannot be excluded.
		/// </summary>
		public string ExcludeFields { get; set; }

		/// <summary>
		/// Sort direction. Acceptable values are: asc, desc.
		/// </summary>
		public string Direction { get; set; }

		/// <summary>
		/// Field name to sort by.
		/// </summary>
		abstract public string Sort { get; set; }


	}
}
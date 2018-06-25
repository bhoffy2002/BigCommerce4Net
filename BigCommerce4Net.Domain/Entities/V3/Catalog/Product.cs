using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BigCommerce4Net.Domain.Entities.V3.Catalog;
using BigCommerce4Net.Domain.ExtensionMethods;
using BigCommerce4Net.Domain.V3.Misc;
using Newtonsoft.Json;

namespace BigCommerce4Net.Domain.V3.Catalog
{
	public class Product : EntityBaseV3PkInt
	{

        #region JsonProperty Names (JPN_)...
	    // Used to easily set the JsonProperty Names in one place
        public const string JPN_Name = "name";
		public const string JPN_Type = "type";
		public const string JPN_Sku = "sku";
		public const string JPN_Description = "description";
		public const string JPN_Weight = "weight";
		public const string JPN_Width = "width";
		public const string JPN_Depth = "depth";
		public const string JPN_Height = "height";
		public const string JPN_Price = "price";
		public const string JPN_CostPrice = "cost_price";
		public const string JPN_RetailPrice = "retail_price";
		public const string JPN_SalePrice = "sale_price";
		public const string JPN_TaxClassId = "tax_class_id";
		public const string JPN_ProductTaxCode = "product_tax_code";
		public const string JPN_Categories = "categories";
		public const string JPN_BrandId = "brand_id";
		public const string JPN_InventoryLevel = "inventory_level";
		public const string JPN_InventoryWarningLevel = "inventory_warning_level";
		public const string JPN_InventoryTracking = "inventory_tracking";
		public const string JPN_FixedCostShippingPrice = "fixed_cost_shipping_price";
		public const string JPN_IsFreeShipping = "is_free_shipping";
		public const string JPN_IsVisible = "is_visible";
		public const string JPN_IsFeatured = "is_featured";
		public const string JPN_RelatedProducts = "related_products";
		public const string JPN_Warranty = "warranty";
		public const string JPN_BinPickingNumber = "bin_picking_number";
		public const string JPN_LayoutFile = "layout_file";
		public const string JPN_Upc = "upc";
		public const string JPN_SearchKeywords = "search_keywords";
		public const string JPN_Availability = "availability";
		public const string JPN_AvailabilityDescription = "availability_description";
		public const string JPN_GiftWrappingOptionsType = "gift_wrapping_options_type";
		public const string JPN_GiftWrappingOptionsList = "gift_wrapping_options_list";
		public const string JPN_SortOrder = "sort_order";
		public const string JPN_Condition = "condition";
		public const string JPN_IsConditionShown = "is_condition_shown";
		public const string JPN_OrderQuantityMinimum = "order_quantity_minimum";
		public const string JPN_OrderQuantityMaximum = "order_quantity_maximum";
		public const string JPN_PageTitle = "page_title";
		public const string JPN_MetaKeywords = "meta_keywords";
		public const string JPN_MetaDescription = "meta_description";
		public const string JPN_ViewCount = "view_count";
		public const string JPN_PreorderReleaseDate = "preorder_release_date";
		public const string JPN_PreorderMessage = "preorder_message";
		public const string JPN_IsPreorderOnly = "is_preorder_only";
		public const string JPN_IsPriceHidden = "IsPriceHidden";
		public const string JPN_PriceHiddenLabel = "price_hidden_label";
		public const string JPN_CustomUrl = "custom_url";
		public const string JPN_OpenGraphType = "open_graph_type";
		public const string JPN_OpenGraphTitle = "open_graph_title";
		public const string JPN_OpenGraphDescription = "open_graph_description";
		public const string JPN_OpenGraphUseMetaDescription = "open_graph_use_meta_description";
		public const string JPN_OpenGraphUseProductName = "open_graph_use_product_name";
		public const string JPN_OpenGraphUseImage = "open_graph_use_image";
		public const string JPN_Id = "id";
		public const string JPN_CalculatedPrice = "calculated_price";
		public const string JPN_ReviewsRatingSum = "reviews_rating_sum";
		public const string JPN_ReviewsCount = "reviews_count";
		public const string JPN_TotalSold = "total_sold";


		public const string JPN_DateCreated = "date_created";
		public const string JPN_DateModified = "date_modified";
		public const string JPN_BaseVariantId = "base_variant_id";


		#endregion

		#region Private Backing Fields ...
        // Used to tell which fields have values
		private string _name;
		private ProductsType? _type;
		private string _sku;
		private string _description;
		private double? _weight;
		private double? _width;
		private double? _depth;
		private double? _height;
		private decimal? _price;
		private decimal? _costPrice;
		private decimal? _retailPrice;
		private decimal? _salePrice;
		private int? _taxClassId;
		private string _productTaxCode;
		private IList<int> _categories;
		private int? _brandId;
		private int? _inventoryLevel;
		private int? _inventoryWarningLevel;
		private ProductsInventoryTracking? _inventoryTracking;
		private decimal? _fixedCostShippingPrice;
		private bool? _isFreeShipping;
		private bool? _isVisible;
		private bool? _isFeatured;
		private IList<int> _relatedProducts;
		private string _warranty;
		private string _binPickingNumber;
		private string _layoutFile;
		private string _upc;
		private string _searchKeywords;
		private ProductsAvailability? _availability;
		private string _availabilityDescription;
		private ProductGiftWrappingOptionType? _giftWrappingOptionsType;
		private IList<int> _giftWrappingOptionsList;
		private int? _sortOrder;
		private ProductsCondition _condition;
		private bool? _isConditionShown;
		private int? _orderQuantityMinimum;
		private int? _orderQuantityMaximum;
		private string _pageTitle;
		private IList<string> _metaKeywords;
		private string _metaDescription;
		private int? _viewCount;
		private DateTime? _preorderReleaseDate;
		private string _preOrderMessage;
		private bool? _isPreorderOnly;
		private bool? _isPriceHidden;
		private string _priceHiddenLabel;
		private CustomUrl _customUrl;
		private ProductsOpenGraphType? _openGraphType;
		private string _openGraphTtitle;
		private string _openGraphDescription;
		private bool? _openGraphUseMetaDescription;
		private bool? _openGraphUseProductName;
		private bool? _openGraphUseImage;
		//private IList<> _customFields;
		//private IList<> _bulkPricingRules;
		//private IList<> _images;
		//private IList<> _videos;
		//private IList<> _variants;

		#endregion


		/// <summary>
		/// [string(250)] - The product name.
		/// </summary>
		[JsonProperty(JPN_Name)]
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				HasName = true;
			}
		}

		[JsonIgnore] public bool HasName { get; private set; }
		
		/// <summary>
		/// The product type: 
		/// 
		/// physical - a physical stock unit
		/// digital - a digital download
		/// </summary>
		[JsonProperty(JPN_Type)]
		public ProductsType? Type
		{
			get => _type;
			set
			{
				_type = value;
				HasType = true;
			}
		}

		[JsonIgnore] public bool HasType { get; private set; }

		/// <summary>
		/// [string(250)] User defined product code/stock keeping unit (SKU).
		/// </summary>
		[JsonProperty(JPN_Sku)]
		public string Sku
		{
			get => _sku;
			set { _sku = value; }
		}

		[JsonIgnore] public bool HasSku { get; private set; }

		/// <summary>
		/// [Text] The product description, which can include HTML formatting.
		/// </summary>
		[JsonProperty(JPN_Description)]
		public string Description
		{
			get => _description;
			set
			{
				_description = value;
				HasDescription = true;
			}
		}

		[JsonIgnore] public bool HasDescription { get; private set; }

		/// <summary>
		/// [number] Weight of the product, which can be used when calculating shipping costs.
		/// </summary>
		[JsonProperty(JPN_Weight)]
		public double? Weight
		{
			get => _weight;
			set
			{
				_weight = value;
				HasWeight = true;
			}
		}

		public bool HasWeight { get; private set; }

		/// <summary>
		/// [number] Width of the product, which can be used when calculating shipping costs.
		/// </summary>
		[JsonProperty(JPN_Width)]
		public double? Width
		{
			get => _width;
			set
			{
				_width = value;
				HasWidth = true;
			}
		}

		[JsonIgnore] public bool HasWidth { get; private set; }

		/// <summary>
		/// [number] Depth of the product, which can be used when calculating shipping costs.
		/// </summary>
		[JsonProperty(JPN_Depth)]
		public double? Depth
		{
			get => _depth;
			set
			{
				_depth = value;
				HasDepth = true;
			}
		}

		[JsonIgnore] public bool HasDepth { get; private set; }

		/// <summary>
		/// [number] Height of the product, which can be used when calculating shipping costs.
		/// </summary>
		[JsonProperty(JPN_Height)]
		public double? Height
		{
			get => _height;
			set
			{
				_height = value;
				HasHeight = true;
			}
		}

		[JsonIgnore] public bool HasHeight { get; private set; }

		/// <summary>
		/// [number] The price of the product. The price should include or exclude tax, based on the store settings.
		/// </summary>
		[JsonProperty(JPN_Price)]
		public decimal? Price
		{
			get => _price;
			set
			{
				_price = value;
				HasPrice = true;
			}
		}

		[JsonIgnore] public bool HasPrice { get; private set; }

		/// <summary>
		/// [number] The cost price of the product. Stored for reference only; it is not used or displayed anywhere on the store.
		/// </summary>
		[JsonProperty(JPN_CostPrice)]
		public decimal? CostPrice
		{
			get => _costPrice;
			set
			{
				_costPrice = value;
				HasCostPrice = true;
			}
		}

		[JsonIgnore] public bool HasCostPrice { get; private set; }

		/// <summary>
		/// [number] The retail cost of the product. If entered, the retail cost price will be shown on the product page.
		/// </summary>
		[JsonProperty(JPN_RetailPrice)]
		public decimal? RetailPrice
		{
			get => _retailPrice;
			set
			{
				_retailPrice = value;
				HasRetailPrice = true;
			}
		}

		[JsonIgnore] public bool HasRetailPrice { get; private set; }

		/// <summary>
		/// [number] If entered, the sale price will be used instead of value in the price field when calculating the product's cost.
		/// </summary>
		[JsonProperty(JPN_SalePrice)]
		public decimal? SalePrice
		{
			get => _salePrice;
			set
			{
				_salePrice = value;
				HasSalePrice = true;
			}
		}

		[JsonIgnore] public bool HasSalePrice { get; private set; }

		/// <summary>
		/// [number] The ID of the tax class applied to the product. (NOTE: Value ignored if automatic tax is enabled.)
		/// </summary>
		[JsonProperty(JPN_TaxClassId)]
		public int? TaxClassId
		{
			get => _taxClassId;
			set
			{
				_taxClassId = value;
				HasTaxClassId = true;
			}
		}

		[JsonIgnore] public bool HasTaxClassId { get; private set; }

		/// <summary>
		/// [string] Accepts AvaTax System Tax Codes, which identify products and services that fall into special sales-tax categories. By using these codes, merchants who subscribe to BigCommerce's Avalara Premium integration can calculate sales taxes more accurately. Stores without Avalara Premium will ignore the code when calculating sales tax. Do not pass more than one code. The codes are case-sensitive. For details, please see Avalara's documentation.
		/// </summary>
		[JsonProperty(JPN_ProductTaxCode)]
		public string ProductTaxCode
		{
			get => _productTaxCode;
			set
			{
				_productTaxCode = value;
				HasProductTaxCode = true;
			}
		}

		[JsonIgnore] public bool HasProductTaxCode { get; private set; }

		/// <summary>
		/// [int array] An array of IDs for the categories to which this product belongs. When updating a product, if an array of categories is supplied, all product categories will be overwritten. Does not accept more than 1,000 ID values.
		/// </summary>
		[JsonProperty(JPN_Categories)]
		public IList<int> Categories
		{
			get => _categories;
			set
			{
				_categories = value;
				HasCategories = true;
			}
		}

		[JsonIgnore] public bool HasCategories { get; private set; }

		/// <summary>
		/// [number] The ID associated with the products brand.
		/// </summary>
		[JsonProperty(JPN_BrandId)]
		public int? BrandId
		{
			get => _brandId;
			set
			{
				_brandId = value;
				HasBrandId = true;
			}
		}

		[JsonIgnore] public bool HasBrandId { get; private set; }

		/// <summary>
		/// [number] Current inventory level of the product. Simple inventory tracking must be enabled (See the inventory_tracking field) for this to take any effect.
		/// </summary>
		[JsonProperty(JPN_InventoryLevel)]
		public int? InventoryLevel
		{
			get => _inventoryLevel;
			set
			{
				_inventoryLevel = value;
				HasInventoryLevel = true;
			}
		}

		[JsonIgnore] public bool HasInventoryLevel { get; private set; }

		/// <summary>
		/// [number] Inventory warning level for the product. When the product's inventory level drops below the warning level, the store owner will be informed. Simple inventory tracking must be enabled (see the inventory_tracking field) for this to take any effect.
		/// </summary>
		[JsonProperty(JPN_InventoryWarningLevel)]
		public int? InventoryWarningLevel
		{
			get => _inventoryWarningLevel;
			set
			{
				_inventoryWarningLevel = value;
				HasInventoryWarningLevel = true;
			}
		}

		[JsonIgnore] public bool HasInventoryWarningLevel { get; private set; }

		/// <summary>
		///	The type of inventory tracking for the product: 
		///	none - inventory levels will not be tracked.
		///	simple - inventory levels will be tracked using the "inventory_level" and "inventory_warning_level" fields.
		///	sku - inventory levels will be tracked based on individual product options which maintain their own warning levels and inventory levels.
		/// </summary>
		[JsonProperty(JPN_InventoryTracking)]
		public ProductsInventoryTracking? InventoryTracking
		{
			get => _inventoryTracking;
			set
			{
				_inventoryTracking = value;
				HasInventoryTracking = true;
			}
		}

		[JsonIgnore] public bool HasInventoryTracking { get; private set; }

		/// <summary>
		/// [number] A fixed shipping cost for the product. If defined, this value will be used during checkout instead of normal shipping-cost calculation.
		/// </summary>
		[JsonProperty(JPN_FixedCostShippingPrice)]
		public decimal? FixedCostShippingPrice
		{
			get => _fixedCostShippingPrice;
			set
			{
				_fixedCostShippingPrice = value;
				HasFixedCostShippingPrice = true;
			}
		}

		[JsonIgnore] public bool HasFixedCostShippingPrice { get; private set; }

		/// <summary>
		/// [boolean] Flag used to indicate whether the product has free shipping. If true, the shipping cost for the product will be zero.
		/// </summary>
		[JsonProperty(JPN_IsFreeShipping)]
		public bool? IsFreeShipping
		{
			get => _isFreeShipping;
			set
			{
				_isFreeShipping = value;
				HasIsFreeShipping = true;
			}
		}

		[JsonIgnore] public bool HasIsFreeShipping { get; private set; }

		/// <summary>
		/// [boolean] Flag to determine whether the product should be displayed to customers browsing the store. If true, the product will be displayed. If false, the product will be hidden from view.
		/// </summary>
		[JsonProperty(JPN_IsVisible)]
		public bool? IsVisible
		{
			get => _isVisible;
			set
			{
				_isVisible = value;
				HasIsVisible = true;
			}
		}

		[JsonIgnore] public bool HasIsVisible { get; private set; }

		/// <summary>
		/// [boolean] Flag to determine whether the product should be included in the featured products panel when viewing the store.
		/// </summary>
		[JsonProperty(JPN_IsFeatured)]
		public bool? IsFeatured
		{
			get => _isFeatured;
			set
			{
				_isFeatured = value;
				HasIsFeatured = true;
			}
		}

		[JsonIgnore] public bool HasIsFeatured { get; private set; }

		/// <summary>
		/// [int array] An array of IDs for the related products.
		/// </summary>
		[JsonProperty(JPN_RelatedProducts)]
		public IList<int> RelatedProducts
		{
			get => _relatedProducts;
			set
			{
				_relatedProducts = value;
				HasRelatedProducts = true;
			}
		}

		[JsonIgnore] public bool HasRelatedProducts { get; private set; }

		/// <summary>
		/// [text] Warranty information displayed on the product page. Can include HTML formatting.
		/// </summary>
		[JsonProperty(JPN_Warranty)]
		public string Warranty
		{
			get => _warranty;
			set
			{
				_warranty = value;
				HasWarranty = true;
			}
		}

		[JsonIgnore] public bool HasWarranty { get; private set; }

		/// <summary>
		/// [string(255)] The BIN picking number for the product.
		/// </summary>
		[JsonProperty(JPN_BinPickingNumber)]
		public string BinPickingNumber
		{
			get => _binPickingNumber;
			set
			{
				_binPickingNumber = value;
				HasBinPickingNumber = true;
			}
		}

		[JsonIgnore] public bool HasBinPickingNumber { get; private set; }

		/// <summary>
		/// [string(50)] The layout template file used to render this product.
		/// </summary>
		[JsonProperty(JPN_LayoutFile)]
		public string LayoutFile
		{
			get => _layoutFile;
			set
			{
				_layoutFile = value;
				HasLayoutFile = true;
			}
		}

		[JsonIgnore] public bool HasLayoutFile { get; private set; }

		/// <summary>
		/// [string(32)] The product UPC code, which is used in feeds for shopping comparison sites and external channel integrations.
		/// </summary>
		[JsonProperty(JPN_Upc)]
		public string Upc
		{
			get => _upc;
			set
			{
				_upc = value;
				HasUpc = true;
			}
		}

		[JsonIgnore] public bool HasUpc { get; private set; }

		/// <summary>
		/// [text] A comma-separated list of keywords that can be used to locate the product when searching the store.
		/// </summary>
		[JsonProperty(JPN_SearchKeywords)]
		public string SearchKeywords
		{
			get => _searchKeywords;
			set
			{
				_searchKeywords = value;
				HasSeachKeywords = true;
			}
		}

		[JsonIgnore] public bool HasSeachKeywords { get; private set; }

		/// <summary>
		/// Availability of the product. availability options: 
		///	available - The product can be purchased in the store front.
		///	disabled - The product is listed in the store front but can not be purchased.
		///	preorder - The product is listed for pre-orders.
		/// </summary>
		[JsonProperty(JPN_Availability)]
		public ProductsAvailability? Availability
		{
			get => _availability;
			set
			{
				_availability = value;
				HasAvailability = true;
			}
		}

		[JsonIgnore] public bool HasAvailability { get; private set; }

		/// <summary>
		/// [string(250)] Availability text displayed on the checkout page, under the product title. Tells the customer how long it will normally take to ship this product, such as: 'Usually ships in 24 hours.'
		/// </summary>
		[JsonProperty(JPN_AvailabilityDescription)]
		public string AvailabilityDescription
		{
			get => _availabilityDescription;
			set
			{
				_availabilityDescription = value;
				HasAvailability = true;
			}
		}

		[JsonIgnore] public bool HasAvailabilityDescription { get; private set; }

		/// <summary>
		/// Type of gift-wrapping options. Values: any - allow any gift-wrapping options in the store; none - disallow gift-wrapping on the product; list – provide a list of IDs in the gift_wrapping_options_list field.
		/// - any
		/// - none 
		/// - list
		/// </summary>
		[JsonProperty(JPN_GiftWrappingOptionsType)]
		public ProductGiftWrappingOptionType? GiftWrappingOptionsType
		{
			get => _giftWrappingOptionsType;
			set
			{
				_giftWrappingOptionsType = value;
				HasGiftWrappingOptionsType = true;
			}
		}

		[JsonIgnore] public bool HasGiftWrappingOptionsType { get; private set; }

		/// <summary>
		/// [int array] A list of gift-wrapping option IDs.
		/// </summary>
		[JsonProperty(JPN_GiftWrappingOptionsList)]
		public IList<int> GiftWrappingOptionsList
		{
			get => _giftWrappingOptionsList;
			set
			{
				_giftWrappingOptionsList = value;
				HasGiftWrappingOptionsList = true;
			}
		}

		[JsonIgnore] public bool HasGiftWrappingOptionsList { get; private set; }

		/// <summary>
		/// [number] Priority to give this product when included in product lists on category pages and in search results. Lower integers will place the product closer to the top of the results.
		/// </summary>
		[JsonProperty(JPN_SortOrder)]
		public int? SortOrder
		{
			get => _sortOrder;
			set
			{
				_sortOrder = value;
				HasSortOrder = true;
			}
		}

		[JsonIgnore] public bool HasSortOrder { get; private set; }

		/// <summary>
		/// The product condition, will be shown on the product page if the value of 
		/// the "is_condition_shown" field is true. Possible values: 
		///	New
		///	Used
		///	Refurbished
		/// </summary>
		[JsonProperty(JPN_Condition)]
		public ProductsCondition Condition
		{
			get => _condition;
			set
			{
				_condition = value;
				HasCondition = true;
			}
		}

		[JsonIgnore] public bool HasCondition { get; set; }

		/// <summary>
		/// [boolean] Flag used to determine whether the product condition is shown to the customer on the product page.
		/// </summary>
		[JsonProperty(JPN_IsConditionShown)]
		public bool? IsConditionShown
		{
			get => _isConditionShown;
			set
			{
				_isConditionShown = value;
				HasIsConditionShown = true;
			}
		}

		[JsonIgnore] public bool HasIsConditionShown { get; private set; }

		/// <summary>
		/// [number] The minimum quantity an order must contain, to be eligible to purchase this product.
		/// </summary>
		[JsonProperty(JPN_OrderQuantityMinimum)]
		public int? OrderQuantityMinimum
		{
			get => _orderQuantityMinimum;
			set
			{
				_orderQuantityMinimum = value;
				HasOrderQuantityMinimum = true;
			}
		}

		[JsonIgnore] public bool HasOrderQuantityMinimum { get; private set; }

		/// <summary>
		/// [number] The maximum quantity an order can contain when purchasing the product.
		/// </summary>
		[JsonProperty(JPN_OrderQuantityMaximum)]
		public int? OrderQuantityMaximum
		{
			get => _orderQuantityMaximum;
			set
			{
				_orderQuantityMaximum = value;
				HasOrderQuantityMaximum = true;
			}
		}

		[JsonIgnore] public bool HasOrderQuantityMaximum { get; private set; }

		/// <summary>
		/// [string(250)] Custom title for the product page. If not defined, the product name will be used as the meta title.
		/// </summary>
		[JsonProperty(JPN_PageTitle)]
		public string PageTitle
		{
			get => _pageTitle;
			set
			{
				_pageTitle = value;
				HasPageTitle = true;
			}
		}

		[JsonIgnore] public bool HasPageTitle { get; private set; }

		/// <summary>
		/// [string array] Custom meta keywords for the product page. If not defined, the store's default keywords will be used.
		/// </summary>
		[JsonProperty(JPN_MetaKeywords)]
		public IList<string> MetaKeywords
		{
			get => _metaKeywords;
			set
			{
				_metaKeywords = value;
				HasMetaKeywords = true;
			}
		}

		[JsonIgnore] public bool HasMetaKeywords { get; private set; }

		/// <summary>
		/// [text] Custom meta description for the product page. If not defined, the store's default meta description will be used.
		/// </summary>
		[JsonProperty(JPN_MetaDescription)]
		public string MetaDescription
		{
			get => _metaDescription;
			set
			{
				_metaDescription = value;
				HasMetaDescription = true;
			}
		}

		[JsonIgnore] public bool HasMetaDescription { get; private set; }

		/// <summary>
		/// [number] The number of times the product has been viewed.
		/// </summary>
		[JsonProperty(JPN_ViewCount)]
		public int? ViewCount
		{
			get => _viewCount;
			set
			{
				_viewCount = value;
				HasViewCount = true;
			}
		}

		[JsonIgnore] public bool HasViewCount { get; private set; }

		/// <summary>
		/// Pre-order release date. See the availability field for details on setting a product's availability to accept pre-orders.
		/// </summary>
		[JsonIgnore]
		public DateTime? PreorderReleaseDate
		{
			get => _preorderReleaseDate;
			set
			{
				_preorderReleaseDate = value;
				HasPreorderReleaseDate = true;
			}
		}

		[JsonProperty(JPN_PreorderReleaseDate)]
		public string PreorderReleaseDateUT
		{
			get => PreorderReleaseDate.DateTimeToString();
			set
			{
				PreorderReleaseDate = value.StringToDateTime();
				HasPreorderReleaseDate = true;
			}
		}

		[JsonIgnore] public bool HasPreorderReleaseDate { get; private set; }

		/// <summary>
		/// [string] Custom expected-date message to display on the product page. If undefined, the message defaults to the storewide setting. Can contain the %%DATE%% placeholder, which will be substituted for the release date.
		/// </summary>
		[JsonProperty(JPN_PreorderMessage)]
		public string PreOrderMessage
		{
			get => _preOrderMessage;
			set
			{
				_preOrderMessage = value;
				HasPreOrderMessage = true;
			}
		}

		[JsonIgnore] public bool HasPreOrderMessage { get; private set; }

		/// <summary>
		/// [boolean] If set to false, the product will not change its availability from preorder to available on the release date. Otherwise, on the release date the product's availability/status will change to available.
		/// </summary>
		[JsonProperty(JPN_IsPreorderOnly)]
		public bool? IsPreorderOnly
		{
			get => _isPreorderOnly;
			set
			{
				_isPreorderOnly = value;
				HasIsPreorderOnly = true;
			}
		}

		[JsonIgnore] public bool HasIsPreorderOnly { get; private set; }

		/// <summary>
		/// [boolean] False by default, indicating that this product's price should be shown on the product page. If set to true, the price is hidden. (NOTE: To successfully set is_price_hidden to true, the availability value must be disabled.)
		/// </summary>
		[JsonProperty(JPN_IsPriceHidden)]
		public bool? IsPriceHidden
		{
			get => _isPriceHidden;
			set
			{
				_isPriceHidden = value;
				HasIsPriceHidden = true;
			}
		}

		[JsonIgnore] public bool HasIsPriceHidden { get; private set; }

		/// <summary>
		/// [boolean] By default, an empty string. If is_price_hidden is true, the value of price_hidden_label is displayed instead of the price. (NOTE: To successfully set a non-empty string value with is_price_hidden set to true, the availability value must be disabled.)
		/// </summary>
		[JsonProperty(JPN_PriceHiddenLabel)]
		public string PriceHiddenLabel
		{
			get => _priceHiddenLabel;
			set
			{
				_priceHiddenLabel = value;
				HasPriceHiddenLabel = true;
			}
		}

		[JsonIgnore] public bool HasPriceHiddenLabel { get; private set; }

		/// <summary>
		/// [object] The custom URL for the product on the storefront.
		/// </summary>
		[JsonProperty(JPN_CustomUrl)]
		public CustomUrl CustomUrl
		{
			get => _customUrl;
			set
			{
				_customUrl = value;
				HasCustomUrl = true;
			}
		}

		[JsonIgnore] public bool HasCustomUrl { get; private set; }

		/// <summary>
		/// Type of product, valid values are: 
		/// product
		///	album
		///	book
		///	drink
		///	food
		///	game
		///	movie
		///	song
		///	tv_show
		/// </summary>
		[JsonProperty(JPN_OpenGraphType)]
		public ProductsOpenGraphType? OpenGraphType
		{
			get => _openGraphType;
			set
			{
				_openGraphType = value;
				HasOpenGraphType = true;
			}
		}

		[JsonIgnore] public bool HasOpenGraphType { get; private set; }

		/// <summary>
		/// [string(250)] Title of the product, if not specified the product name will be used instead.
		/// </summary>
		[JsonProperty(JPN_OpenGraphTitle)]
		public string OpenGraphTtitle
		{
			get => _openGraphTtitle;
			set
			{
				_openGraphTtitle = value;
				HasOpenGraphTitle = true;
			}
		}

		[JsonIgnore] public bool HasOpenGraphTitle { get; private set; }

		/// <summary>
		/// [string(250)] Description to use for the product, if not specified then the meta_description will be used instead.
		/// </summary>
		[JsonProperty(JPN_OpenGraphDescription)]
		public string OpenGraphDescription
		{
			get => _openGraphDescription;
			set
			{
				_openGraphDescription = value;
				HasOpenGraphDescription = true;
			}
		}

		[JsonIgnore] public bool HasOpenGraphDescription { get; private set; }

		/// <summary>
		/// [boolean] Flag to determine if product description or open graph description is used.
		/// </summary>
		[JsonProperty(JPN_OpenGraphUseMetaDescription)]
		public bool? OpenGraphUseMetaDescription
		{
			get => _openGraphUseMetaDescription;
			set
			{
				_openGraphUseMetaDescription = value;
				HasOpenGraphUseMetaDescription = true;
			}
		}

		[JsonIgnore] public bool HasOpenGraphUseMetaDescription { get; private set; }

		/// <summary>
		/// [boolean] Flag to determine if product name or open graph name is used.
		/// </summary>
		[JsonProperty(JPN_OpenGraphUseProductName)]
		public bool? OpenGraphUseProductName
		{
			get => _openGraphUseProductName;
			set
			{
				_openGraphUseProductName = value;
				HasOpenGraphUseProductName = true;
			}
		}

		[JsonIgnore] public bool HasOpenGraphUseProductName { get; private set; }

		/// <summary>
		/// [boolean] Flag to determine if product image or open graph image is used.
		/// </summary>
		[JsonProperty(JPN_OpenGraphUseImage)]
		public bool? OpenGraphUseImage
		{
			get => _openGraphUseImage;
			set
			{
				_openGraphUseImage = value;
				HasOpenGraphUseImage = true;
			}
		}

		[JsonIgnore] public bool HasOpenGraphUseImage { get; private set; }

		/// <summary>
		/// [number] The unique numeric ID of the product; increments sequentially.
		/// </summary>
		[JsonProperty(JPN_Id)]
		public int? Id { get; set; }

		/// <summary>
		/// [number] The price of the product as seen on the storefront. It will be equal to the sale_price, if set, and the price if there is not a sale_price.
		/// </summary>
		[JsonProperty(JPN_CalculatedPrice)]
		public decimal? CalculatedPrice { get; set; }


		/// <summary>
		/// [number] The total rating for the product.
		/// </summary>
		[JsonProperty(JPN_ReviewsRatingSum)]
		public double? ReviewsRatingSum { get; set; }

		
		/// <summary>
		/// [number] The number of times the product has been rated.
		/// </summary>
		[JsonProperty(JPN_ReviewsCount)]
		public int ReviewsCount { get; set; }



		/// <summary>
		/// [number] The total quantity of this product sold.
		/// </summary>
		[JsonProperty(JPN_TotalSold)]
		public int? TotalSold { get; set; }

		///// <summary>
		///// [Products.CustomField array] 
		///// </summary>
		//[JsonProperty("custom_fields")]
		//public IList<> CustomFields
		//{
		//	get => _customFields;
		//	set
		//	{
		//		_customFields = value;
		//		HasCustomFields = true;
		//	}
		//}

		//[JsonIgnore] public bool HasCustomFields { get; private set; }

		///// <summary>
		///// [Products.BulkPricingRules array]
		///// </summary>
		//[JsonProperty("bulk_pricing_rules")]
		//public IList<> BulkPricingRules
		//{
		//	get => _bulkPricingRules;
		//	set
		//	{
		//		_bulkPricingRules = value;
		//		HasBulkPricingRules = true;
		//	}
		//}

		//[JsonIgnore] public bool HasBulkPricingRules { get; private set; }

		/// <summary>
		/// The date on which the product was created.
		/// </summary>
		[JsonIgnore]
		public DateTime? DateCreated { get; set; }

		[JsonProperty(JPN_DateCreated)]
		public string DateCreatedUT
		{
			get => DateCreated.DateTimeToString();
			set => DateCreated = value.StringToDateTime();
		}

		/// <summary>
		/// The date on which the product was modified.
		/// </summary>
		[JsonIgnore]
		public DateTime? DateModified { get; set; }

		[JsonProperty(JPN_DateModified)]
		public string DateModifiedUT
		{
			get => DateModified.DateTimeToString();
			set => DateModified = value.StringToDateTime();
		}

		///// <summary>
		///// [Products.Image array]
		///// </summary>
		//[JsonProperty("images")]
		//public IList<> Images
		//{
		//	get => _images;
		//	set
		//	{
		//		_images = value;
		//		HasImages = true;
		//	}
		//}

		//[JsonIgnore] public bool HasImages { get; private set; }

		///// <summary>
		///// Products.Video array]
		///// </summary>
		//[JsonProperty("videos")]
		//public IList<> Videos
		//{
		//	get => _videos;
		//	set
		//	{
		//		_videos = value;
		//		HasVideos = true;
		//	}
		//}

		//[JsonIgnore] public bool HasVideos { get; private set; }

		///// <summary>
		///// Products.Variant array]
		///// </summary>
		//[JsonProperty("variants")]
		//public IList<> Variants
		//{
		//	get => _variants;
		//	set
		//	{
		//		_variants = value;
		//		HasVariants = true;
		//	}
		//}

		[JsonIgnore] public bool HasVariants { get; private set; }

		/// <summary>
		/// The unique identifier of the base variant associated with a simple product. This value is null for complex products.
		/// </summary>
		[JsonProperty(JPN_BaseVariantId)]
		public int? BaseVariantId { get; set; }
	}
}

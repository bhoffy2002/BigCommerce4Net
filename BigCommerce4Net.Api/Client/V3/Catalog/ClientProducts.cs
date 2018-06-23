using System.Collections.Generic;
using BigCommerce4Net.Api.Deserializers;
using BigCommerce4Net.Domain;
using BigCommerce4Net.Api.V3;
using BigCommerce4Net.Domain.V3.Catalog;
using BigCommerce4Net.Domain.V3.Misc;
using BigCommerce4Net.V3.Catalog;
using Product = BigCommerce4Net.Domain.V3.Catalog.Product;

namespace BigCommerce4Net.Api.V3.Catalog
{
	public class ClientProducts : ParentEntityGetUpdateDeleteCreate<Product>
	{
		public ClientProducts(Configuration configuration) : base(configuration)
		{
			base.resourceEndpoint_base = "/v3/catalog/products";
		}
		
		public override object GetIdFromEntity(Product entity)
		{
			//return entity.Id;
			return 0;
		}

		public override void JsonIgnoresForUpdate(PropertyIgnoreSerializerContractResolver jsonResolver, Product entity)
		{
			if (!entity.HasName) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Name); }
		}

		public override void CommonJsonIgnores(PropertyIgnoreSerializerContractResolver jsonResolver, Product entity)
		{
			if (!entity.HasType) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Type); }
			if (!entity.HasSku) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Sku); }
			if (!entity.HasDescription) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Description); }
			if (!entity.HasWeight) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Weight); }
			if (!entity.HasWidth) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Width); }
			if (!entity.HasDepth) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Depth); }
			if (!entity.HasHeight) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Height); }
			if (!entity.HasPrice) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Price); }
			if (!entity.HasCostPrice) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_CostPrice); }
			if (!entity.HasRetailPrice) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_RetailPrice); }
			if (!entity.HasSalePrice) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_SalePrice); }
			if (!entity.HasTaxClassId) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_TaxClassId); }
			if (!entity.HasProductTaxCode) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_ProductTaxCode); }
			if (!entity.HasCategories) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Categories); }
			if (!entity.HasBrandId) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_BrandId); }
			if (!entity.HasInventoryLevel) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_InventoryLevel); }
			if (!entity.HasInventoryWarningLevel) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_InventoryWarningLevel); }
			if (!entity.HasInventoryTracking) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_InventoryTracking); }
			if (!entity.HasFixedCostShippingPrice) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_FixedCostShippingPrice); }
			if (!entity.HasIsFreeShipping) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_IsFreeShipping); }
			if (!entity.HasIsVisible) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_IsVisible); }
			if (!entity.HasIsFeatured) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_IsFeatured); }
			if (!entity.HasRelatedProducts) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_RelatedProducts); }
			if (!entity.HasWarranty) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Warranty); }
			if (!entity.HasBinPickingNumber) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_BinPickingNumber); }
			if (!entity.HasLayoutFile) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_LayoutFile); }
			if (!entity.HasUpc) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Upc); }
			if (!entity.HasSeachKeywords) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_SearchKeywords); }
			if (!entity.HasAvailability) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Availability); }
			if (!entity.HasAvailabilityDescription) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_AvailabilityDescription); }
			if (!entity.HasGiftWrappingOptionsType) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_GiftWrappingOptionsType); }
			if (!entity.HasGiftWrappingOptionsList) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_GiftWrappingOptionsList); }
			if (!entity.HasSortOrder) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_SortOrder); }
			if (!entity.HasCondition) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Condition); }
			if (!entity.HasIsConditionShown) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_IsConditionShown); }
			if (!entity.HasOrderQuantityMinimum) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_OrderQuantityMinimum); }
			if (!entity.HasOrderQuantityMaximum) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_OrderQuantityMaximum); }
			if (!entity.HasPageTitle) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_PageTitle); }
			if (!entity.HasMetaKeywords) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_MetaKeywords); }
			if (!entity.HasMetaDescription) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_MetaDescription); }
			if (!entity.HasViewCount) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_ViewCount); }
			if (!entity.HasPreorderReleaseDate) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_PreorderReleaseDate); }
			if (!entity.HasPreOrderMessage) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_PreorderMessage); }
			if (!entity.HasIsPreorderOnly) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_IsPreorderOnly); }
			if (!entity.HasIsPriceHidden) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_IsPriceHidden); }
			if (!entity.HasPriceHiddenLabel) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_PriceHiddenLabel); }
			if (!entity.HasCustomUrl) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_CustomUrl); }
			if (!entity.HasOpenGraphType) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_OpenGraphType); }
			if (!entity.HasOpenGraphTitle) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_OpenGraphTitle); }
			if (!entity.HasOpenGraphDescription) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_OpenGraphDescription); }
			if (!entity.HasOpenGraphUseMetaDescription) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_OpenGraphUseMetaDescription); }
			if (!entity.HasOpenGraphUseProductName) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_OpenGraphUseProductName); }
			if (!entity.HasOpenGraphUseImage) { jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_OpenGraphUseImage); }
			



			//Always exclude the "id" property
			jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_Id);
			jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_CalculatedPrice);
			jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_ReviewsRatingSum);
			jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_ReviewsCount);
			jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_TotalSold);
			jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_DateCreated);
			jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_DateModified);
			jsonResolver.IgnoreProperty(typeof(Product), "images");
			jsonResolver.IgnoreProperty(typeof(Product), "videos");
			jsonResolver.IgnoreProperty(typeof(Product), Product.JPN_BaseVariantId);

		}
		
		public override void JsonIgnoresForCreate(PropertyIgnoreSerializerContractResolver jsonResolver, Product entity)
		{
			throw new System.NotImplementedException();
		}
	}
}
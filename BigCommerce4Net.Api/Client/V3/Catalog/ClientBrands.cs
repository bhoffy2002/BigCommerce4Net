using BigCommerce4Net.Api.Deserializers;
using BigCommerce4Net.Api.ExtensionMethods;
using BigCommerce4Net.Domain.Entities.V3.Catalog;
using BigCommerce4Net.Domain.V3.Catalog;
using BigCommerce4Net.Domain.V3.Misc;
using BigCommerce4Net.V3.Catalog;
using Newtonsoft.Json;

namespace BigCommerce4Net.Api.V3.Catalog
{
	public class ClientBrands : ParentEntityGetUpdateDeleteCreate<Brand>
	{
		public ClientBrands(Configuration configuration) : base(configuration)
		{
			base.resourceEndpoint_base = "/v3/catalog/brands";
		}

		public override object GetIdFromEntity(Brand entity)
		{
			return entity.Id;
		}

		public override void JsonIgnoresForUpdate(PropertyIgnoreSerializerContractResolver jsonResolver, Brand entity)
		{
			if (!entity.HasName) { jsonResolver.IgnoreProperty(typeof(Brand), "name"); }
		}

		public override void CommonJsonIgnores(PropertyIgnoreSerializerContractResolver jsonResolver, Brand entity)
		{
			if (!entity.HasPageTitle) { jsonResolver.IgnoreProperty(typeof(Brand), "page_title"); }
			if (!entity.HasMetaKeywords) { jsonResolver.IgnoreProperty(typeof(Brand), "meta_keywords"); }
			if (!entity.HasMetaDescription) { jsonResolver.IgnoreProperty(typeof(Brand), "meta_description"); }
			if (!entity.HasSearchKeywords) { jsonResolver.IgnoreProperty(typeof(Brand), "search_keywords"); }
			if (!entity.HasImageUrl) { jsonResolver.IgnoreProperty(typeof(Brand), "image_url"); }
			if (!entity.HasCustomUrl) { jsonResolver.IgnoreProperty(typeof(Brand), "custom_url"); }

			//Always exclude the "id" property
			jsonResolver.IgnoreProperty(typeof(Brand), "id");
		}

		public override void JsonIgnoresForCreate(PropertyIgnoreSerializerContractResolver jsonResolver, Brand entity)
		{
			// nothing to add here
		}
		
	}
}
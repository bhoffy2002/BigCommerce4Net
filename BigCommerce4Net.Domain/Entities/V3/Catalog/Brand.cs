using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigCommerce4Net.Domain.V3;
using Newtonsoft.Json;

namespace BigCommerce4Net.Domain.Entities.V3.Catalog
{
	public class Brand : EntityBaseV3PkInt
	{
		#region JsonProperty Names (JPN_)...
		private const string JPN_Name = "name";
		private const string JPN_Title = "page_title";
		private const string JPN_MetaKeywords = "meta_keywords";
		private const string JPN_MetaDescription = "meta_description";
		private const string JPN_SearchKeywords = "search_keywords";
		private const string JPN_ImageUrl = "image_url";
		private const string JPN_CustomUrl = "custom_url";
		private const string JPN_Id = "id";

		#endregion

		#region Private Backing Fields ...
		private string _name;
		private string _pageTitle;
		private string _metaKeywords;
		private string _metaDescription;
		private string _searchKeywords;
		private string _imageUrl;
		private CustomUrl _customUrl;
		#endregion


		public Brand()
		{
			//HasName = false;
			//HasPageTitle = false;
			//HasMetaKeywords = false;
			//HasMetaDescription = false;
			//HasSearchKeywords = false;
			//HasImageUrl = false;
			//HasCustomUrl = false;
		}

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

		[JsonIgnore]
		public bool HasName { get; private set; }

		[JsonProperty(JPN_Title)]
		public string PageTitle
		{
			get => _pageTitle;
			set
			{
				_pageTitle = value;
				HasPageTitle = true;
			}
		}

		[JsonIgnore]
		public bool HasPageTitle { get; private set; }

		[JsonProperty(JPN_MetaKeywords)]
		public string MetaKeywords
		{
			get => _metaKeywords;
			set
			{
				_metaKeywords = value;
				HasMetaKeywords = true;
			}
		}

		[JsonIgnore]
		public bool HasMetaKeywords { get; private set; }

		[JsonIgnore]
		public string[] MetaKeywordsArray => _metaKeywords.Split(',');

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

		[JsonIgnore]
		public bool HasMetaDescription { get; private set; }

		[JsonProperty(JPN_SearchKeywords)]
		public string SearchKeywords
		{
			get => _searchKeywords;
			set
			{
				_searchKeywords = value;
				HasSearchKeywords = true;
			}
		}

		[JsonIgnore]
		public bool HasSearchKeywords { get; private set; }

		[JsonIgnore]
		public string[] SearchKeywordsArray => _searchKeywords.Split(',');

		[JsonProperty(JPN_ImageUrl)]
		public string ImageUrl
		{
			get => _imageUrl;
			set
			{
				_imageUrl = value;
				HasImageUrl = true;
			}
		}

		[JsonIgnore]
		public bool HasImageUrl { get; private set; }

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

		[JsonIgnore]
		public bool HasCustomUrl { get; private set; }


		[JsonProperty(JPN_Id)]
		public int? Id { get; set; }
	}

	public class CustomUrl
	{
		#region JsonProperty Names (JPN_)...
		private const string JPN_Url = "url";
		private const string JPN_IsCustomized = "is_custonized";
		#endregion
		
		[JsonProperty(JPN_Url)]
		public string Url { get; set; }


		[JsonProperty(JPN_IsCustomized)]
		public bool? IsCustomized { get; set; }
	}
	
}

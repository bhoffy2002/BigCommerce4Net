using System;
using BigCommerce4Net.Domain.ExtensionMethods;
using Newtonsoft.Json;

namespace BigCommerce4Net.Domain.Entities.V3.Catalog
{
    public class ProductImage
    {
        private bool? _isThumbnail;
        private int? _sortOrder;
        private string _description;
        private string _imageFile;
        private string _imageUrl;

        #region JsonProperty Names (JPN_)...
        // Used to easily set the JsonProperty Names in one place

        private const string JPN_IsThumbnail = "is_thumbnail";
        private const string JPN_SortOrder = "sort_order";
        private const string JPN_Id = "description";
        private const string JPN_Description = "description";
        private const string JPN_ProductId = "product_id";
        private const string JPN_ImageFile = "image_file";
        private const string JPN_UrlZoom = "url_zoom";
        private const string JPN_UrlStandard = "url_standard";
        private const string JPN_UrlThumbnail = "url_thumbnail";
        private const string JPN_UrlTiny = "UrlTiny";


        #endregion

        #region Private Backing Fields ...
        // Used to tell which fields have values


        #endregion

        /// <summary>
        /// [boolean] Flag for identifying whether the image is used as the product's thumbnail.
        /// </summary>
        [JsonProperty(JPN_IsThumbnail)]
        public bool? IsThumbnail
        {
            get => _isThumbnail;
            set
            {
                _isThumbnail = value;
                HasIsThumbnail = true;
            }
        }

        [JsonIgnore] public bool HasIsThumbnail { get; private set; }

        /// <summary>
        /// [number] The order in which the image will be displayed on the product page. Higher integers give the image a lower priority. When updating, if the image is given a lower priority, all images with a sort_order the same as or greater than the image's new sort_order value will have their sort_orders reordered.
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
        /// [number] The unique numeric ID of the image; increments sequentially.
        /// </summary>
        [JsonProperty(JPN_Id)]
        public int? Id { get; set; }

        /// <summary>
        /// [number] The unique numeric identifier for the product with which the image is associated.
        /// </summary>
        [JsonProperty(JPN_ProductId)]
        public int? ProductId { get; set; }


        /// <summary>
        /// [string] The local path to the original image file uploaded to BigCommerce.
        /// </summary>
        [JsonProperty(JPN_ImageFile)]
        public string ImageFile
        {
            get => _imageFile;
            set
            {
                _imageFile = value;
                HasImageFile = true;
            }
        }

        [JsonIgnore] public bool HasImageFile { get; set; }

        /// <summary>
        /// [string] The zoom URL for this image. By default, this is used as the zoom image on product pages when zoom images are enabled.
        /// </summary>
        [JsonProperty(JPN_UrlZoom)]
        public string UrlZoom { get; set; }

        /// <summary>
        /// [string] The standard URL for this image. By default, this is used for product-page images.
        /// </summary>
        [JsonProperty(JPN_UrlStandard)]
        public string UrlStandard { get; set; }

        /// <summary>
        /// [string] The thumbnail URL for this image. By default, this is the image size used on the category page and in side panels.
        /// </summary>
        [JsonProperty(JPN_UrlThumbnail)]
        public string UrlThumbnail { get; set; }

        /// <summary>
        /// [string] The tiny URL for this image. By default, this is the image size used for thumbnails beneath the product image on a product page.
        /// </summary>
        [JsonProperty(JPN_UrlTiny)]
        public string UrlTiny { get; set; }


        /// <summary>
        /// The date on which the product was modified.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateModified { get; set; }

        [JsonProperty("date_modified")]
        public string DateModifiedUT
        {
            get => DateModified.DateTimeToString();
            set => DateModified = value.StringToDateTime();
        }

        /// <summary>
        /// [string] Used only for Creating Product Images
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                HasImageUrl = true;
            }
        }

        public bool HasImageUrl { get; private set; }
    }
}
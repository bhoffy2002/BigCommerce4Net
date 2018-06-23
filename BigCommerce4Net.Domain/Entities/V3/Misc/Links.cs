using Newtonsoft.Json;

namespace BigCommerce4Net.Domain.V3.Misc
{
	public class Links
	{
		[JsonProperty("next")]
		public string Next { get; set; }

		[JsonProperty("current")]
		public string Current { get; set; }
	}
}
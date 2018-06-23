using System.Collections.Generic;
using BigCommerce4Net.Domain.V3.Misc;

namespace BigCommerce4Net.Api
{
	public interface IClientResponseList<T>
	{
		IList<T> Data { get; set; }
		ReponseMeta Meta { get; set; }

		global::RestSharp.IRestResponse RestResponse { get; set; }
		IList<BigCommerce4Net.Domain.Error> ResponseErrors { get; set; }

	}

	public class ReponseMeta
	{
		public Pagination Pagination { get; set; }
	}

	public interface IClientResponseListV3<T>
	{
		IList<T> Data { get; set; }
		IList<IClientResponse<BigCResult<T>>> Responses { get; set; }
	}
}
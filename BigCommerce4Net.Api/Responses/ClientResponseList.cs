using System.Collections.Generic;
using BigCommerce4Net.Domain;
using BigCommerce4Net.Domain.V3.Misc;
using RestSharp;

namespace BigCommerce4Net.Api
{
	public class ClientResponseList<T> : IClientResponseList<T>
	{
		public IList<T> Data { get; set; }
		public ReponseMeta Meta { get; set; }
		public IRestResponse RestResponse { get; set; }
		public IList<Error> ResponseErrors { get; set; }
	}

	public class ClientResponseListV3<T> : IClientResponseListV3<T>
	{
		public IList<T> Data { get; set; } = new List<T>();
		public IList<IClientResponse<BigCResult<T>>> Responses { get; set; } = new List<IClientResponse<BigCResult<T>>>();
	}
}
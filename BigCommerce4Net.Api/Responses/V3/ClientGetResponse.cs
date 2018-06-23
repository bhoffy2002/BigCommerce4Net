using System.Collections.Generic;
using BigCommerce4Net.Domain;
using BigCommerce4Net.Domain.V3.Misc;
using RestSharp;

namespace BigCommerce4Net.Api.V3
{
	public class ClientGetResponse<T> : IClientGetResponse<T>
	{
		public T Result { get; set; }
		public IRestResponse RestResponse { get; set; }
		public IList<Error> ResponseErrors { get; set; }
		public IList<Pagination> Pagination { get; set; }
	}
}
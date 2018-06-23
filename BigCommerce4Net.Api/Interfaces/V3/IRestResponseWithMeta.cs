using RestSharp;

namespace BigCommerce4Net.Api.V3
{
	public interface IRestResponseWithMeta<TData> : IRestResponse<TData>
	{
		object Meta { get; set; }
	}
}
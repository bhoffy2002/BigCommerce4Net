using System.Collections;
using System.Collections.Generic;

namespace BigCommerce4Net.Api.V3
{
	public interface IClientGetResponse<T> : IClientResponse<T>
	{
		IList<Domain.V3.Misc.Pagination> Pagination { get; set; }
		
	}
}
using System.Collections.Generic;
using BigCommerce4Net.Domain;

namespace BigCommerce4Net.Api
{
	public interface IChildResourcePaging<T>
	{
		IClientResponse<ItemCount> Count(int id, IFilter filter = null);
		IClientResponse<List<T>> Get(int id, IFilter filter = null);

	}
}
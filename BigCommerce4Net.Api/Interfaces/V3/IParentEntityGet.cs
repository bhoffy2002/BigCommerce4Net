using System.Collections.Generic;
using System.Diagnostics;
using BigCommerce4Net.Domain.V3.Misc;

namespace BigCommerce4Net.Api.V3
{
	public interface IParentEntityGet<T>
	{
		//IClientResponse<BigCResult<T>> Get(int id);
		IClientResponse<BigCResult<T>> Get(int id, IFilter filter=null);
		IClientResponse<BigCResult<T>> Get(IFilter filter=null);

		//IClientResponse<BigCResultList<T>> GetList();
		/// <summary>
		/// This type of request can include multiple requests depending on the number of records retreived
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		IClientResponseListV3<T> GetList(IFilter filter = null);
	}

	public abstract class ParentEntityGet<T> : ClientBaseV3, IParentEntityGet<T> where T : new()
	{
		public virtual IClientResponse<BigCResult<T>> Get(int id, IFilter filter = null)
		{
			var resourceEndpoint = string.Format(resourceEndpoint_id, id);
			return GetData<BigCResult<T>>(resourceEndpoint, filter);
		}

		public virtual IClientResponse<BigCResult<T>> Get(IFilter filter = null)
		{
			var results = GetData<BigCResult<T>>(resourceEndpoint_base, filter);
			return results;
		}

		public virtual IClientResponseListV3<T> GetList(IFilter filter = null)
		{
			var results = GetList<T>(resourceEndpoint_base, filter);

			return results;
		}

		protected ParentEntityGet(Configuration configuration) : base(configuration)
		{
		}
	}
}
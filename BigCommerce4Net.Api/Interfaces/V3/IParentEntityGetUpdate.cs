using BigCommerce4Net.Api.Deserializers;
using Newtonsoft.Json;

namespace BigCommerce4Net.Api.V3
{
	public interface IParentEntityGetUpdate<T> : IParentEntityGet<T>
	{
		IClientResponse<T> Update(int id, string json);

		IClientResponse<T> Update(T entity);

		IClientResponse<T> Update(int id, object obj);

		string SerializeEntityForUpdate(T entity);

		object GetIdFromEntity(T entity);

		void JsonIgnoresForUpdate(PropertyIgnoreSerializerContractResolver jsonResolver, T entity);
		void CommonJsonIgnores(PropertyIgnoreSerializerContractResolver jsonResolver, T entity);
	}

	public abstract class ParentEntityGetUpdate<T> : ParentEntityGet<T>, IParentEntityGetUpdate<T> where T : new()

	{
		protected ParentEntityGetUpdate(Configuration configuration) : base(configuration)
		{
		}

		public virtual IClientResponse<T> Update(int id, string json)
		{
			var results = PutData<T>(string.Format(resourceEndpoint_id, id), json);
			return results;
		}

		public virtual IClientResponse<T> Update(T entity)
		{
			var results = PutData<T>(string.Format(base.resourceEndpoint_id, GetIdFromEntity(entity)),
				SerializeEntityForUpdate(entity));
			return results;
		}

		public virtual IClientResponse<T> Update(int id, object obj)
		{
			throw new System.NotImplementedException();
		}

		public virtual string SerializeEntityForUpdate(T entity)
		{
			var jsonResolver = new PropertyIgnoreSerializerContractResolver();
			CommonJsonIgnores(jsonResolver, entity);
			JsonIgnoresForUpdate(jsonResolver, entity);

			var serializerSettings = new JsonSerializerSettings { ContractResolver = jsonResolver };

			return JsonConvert.SerializeObject(entity, serializerSettings);
		}
		public abstract object GetIdFromEntity(T entity);

		public abstract void CommonJsonIgnores(PropertyIgnoreSerializerContractResolver jsonResolver, T entity);
		public abstract void JsonIgnoresForUpdate(PropertyIgnoreSerializerContractResolver jsonResolver, T entity);

	}
}
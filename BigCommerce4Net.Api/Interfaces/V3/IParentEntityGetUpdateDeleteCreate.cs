using BigCommerce4Net.Api.Deserializers;
using BigCommerce4Net.Api.ExtensionMethods;
using Newtonsoft.Json;

namespace BigCommerce4Net.Api.V3
{
	public interface IParentEntityGetUpdateDeleteCreate<T> : IParentEntityGetUpdateDelete<T>
	{
		IClientResponse<T> Create(string json);
		IClientResponse<T> Create(object obj);
		IClientResponse<T> Create(T entity);

		string SerializeEntityForCreate(T entity);

		void JsonIgnoresForCreate(PropertyIgnoreSerializerContractResolver jsonResolver, T entity);
	}

	public abstract class ParentEntityGetUpdateDeleteCreate<T> : ParentEntityGetUpdateDelete<T>,
		IParentEntityGetUpdateDeleteCreate<T> where T : new()
	{
		protected ParentEntityGetUpdateDeleteCreate(Configuration configuration) : base(configuration)
		{
		}

		public virtual IClientResponse<T> Create(string json)
		{
			var results = PostData<T>(resourceEndpoint_base, json);
			return results;
		}

		public virtual IClientResponse<T> Create(object obj)
		{
			var results = PostData<T>(resourceEndpoint_base, obj.SerializeObject());
			return results;
		}

		public virtual IClientResponse<T> Create(T entity)
		{
			var results = PostData<T>(resourceEndpoint_base, SerializeEntityForCreate(entity));
			return results;
		}

		public virtual string SerializeEntityForCreate(T entity)
		{
			var jsonResolver = new PropertyIgnoreSerializerContractResolver();
			CommonJsonIgnores(jsonResolver, entity);
			JsonIgnoresForCreate(jsonResolver, entity);
			
			var serializerSettings = new JsonSerializerSettings { ContractResolver = jsonResolver };

			var json = JsonConvert.SerializeObject(entity, serializerSettings);
			return json;
		}

		public abstract void JsonIgnoresForCreate(PropertyIgnoreSerializerContractResolver jsonResolver, T entity);
		
	}
}
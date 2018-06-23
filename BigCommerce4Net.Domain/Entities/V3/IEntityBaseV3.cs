using Newtonsoft.Json;

namespace BigCommerce4Net.Domain.V3
{
	public interface IEntityBaseV3
	{
		
	}

	public interface IEntityBaseV3PkInt : IEntityBaseV3
	{
		//int? Id { get; set; }
	}

	public abstract class EntityBaseV3 : IEntityBaseV3
	{

	}

	public abstract class EntityBaseV3PkInt : EntityBaseV3, IEntityBaseV3PkInt
	{
		//[JsonProperty("id")]
		//public int? Id { get; set; }
	}
}
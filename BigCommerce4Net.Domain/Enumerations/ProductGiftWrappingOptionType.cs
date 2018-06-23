using System.Runtime.Serialization;

namespace BigCommerce4Net.Domain
{
	public enum ProductGiftWrappingOptionType
	{
		[EnumMember(Value = "any")]
		Any = 0,

		[EnumMember(Value = "none")]
		None = 1,

		[EnumMember(Value = "list")]
		List = 2,
	}
}
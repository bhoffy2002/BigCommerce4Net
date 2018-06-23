namespace BigCommerce4Net.Domain.V3.Misc
{
	public interface IFilter
	{
		int? Limit { get; set; }
		int? Page { get; set; }
	}
}
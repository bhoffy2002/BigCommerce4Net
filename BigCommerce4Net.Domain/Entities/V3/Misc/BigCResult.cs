using System.Collections.Generic;

namespace BigCommerce4Net.Domain.V3.Misc
{
	public class BigCResult<T> : IBigCResult<T>
	{
		public IList<T> Data { get; set; }
		public ReponseMeta Meta { get; set; }
	}

	public class ReponseMeta
	{
		public Pagination Pagination { get; set; }
	}

	public interface IBigCResult<T>
	{
		IList<T> Data { get; set; }
		ReponseMeta Meta { get; set; }
	}
}
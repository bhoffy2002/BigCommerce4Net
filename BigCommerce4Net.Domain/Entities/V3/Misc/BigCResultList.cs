using System.Collections.Generic;

namespace BigCommerce4Net.Domain.V3.Misc
{
	public interface IBigCResultList<T>
	{
		List<BigCResult<T>> ResponseResults { get; set; }
		List<T> List { get; set; }
	}

	public class BigCResultList<T> : IBigCResultList<T>
	{
		public List<BigCResult<T>> ResponseResults { get; set; }
		public List<T> List { get; set; }
		
	}

}
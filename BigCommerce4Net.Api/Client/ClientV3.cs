using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigCommerce4Net.Api.V3.Catalog;

namespace BigCommerce4Net.Api
{
	public class ClientV3
	{
		private readonly Configuration _configuration;

		public ClientV3(Configuration configuration)
		{
			_configuration = configuration;
		}

		private ClientProducts _products;

		public ClientProducts Products => _products ?? (_products = new ClientProducts(_configuration));

		private ClientBrands _brands;

		public ClientBrands Brands => _brands ?? (_brands = new ClientBrands(_configuration));
	}
}

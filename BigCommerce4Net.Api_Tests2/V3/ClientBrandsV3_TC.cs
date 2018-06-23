using BigCommerce4Net.Api;
using BigCommerce4Net.Domain.Entities.V3.Catalog;
using BigCommerce4Net.V3.Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigCommerce4Net.Api_Tests2.V3
{
	[TestClass]
	public class ClientBrandsV3_TC : TestClassBaseV3
	{
		[TestMethod]
		public void Test()
		{
			var response = Client.Brands.Get(new Filter() {Page = 1, Limit = 1});
			Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
			Assert.AreNotEqual(response.Result, null);
		}

		[TestMethod]
		public void TestCreateBrand()
		{
			var response = Client.Brands.Create(new Brand
			{
				Name = "Test Brand"
			});

			Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
			Assert.AreNotEqual(response.Result, null);
		}
		
	}
}
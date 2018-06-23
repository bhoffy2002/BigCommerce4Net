using BigCommerce4Net.Api;
using BigCommerce4Net.V3.Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigCommerce4Net.Api_Tests2.V3
{
	[TestClass]
	public class ClientProductsV3_TC : TestClassBaseV3
	{
		[TestMethod]
		public void Test()
		{
			var response = Client.Products.Get(new ProductFilter{Page = 1, Limit = 1});
			Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
			Assert.AreNotEqual(response.Result?.Data, null);
			Assert.AreNotEqual(response.Result?.Meta, null);
		}

		[TestMethod]
		public void TestList()
		{
			var response = Client.Products.GetList();

			Assert.AreNotEqual(response.Data, null);
		}

		
	}
}
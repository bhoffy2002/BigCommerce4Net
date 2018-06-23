using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace BigCommerce4Net.Api_Tests2._TEMP
{
	[TestClass]
	public class TestRestSharp
	{
		[TestMethod]
		public void Test()
		{
			var baseUri = "https://api.bigcommerce.com/stores/mwv5u7d/v3";
			var resource = "/brands?page=1&limit=1";
			var authToken = "rlxphim8yw9vhwl5suez9gu6iqqtf47";
			var authClient = "67a40m4r05c6bsjzo9dawcbzmhbdgg5";

			var client = new RestSharp.RestClient(baseUri);
			var request = new RestSharp.RestRequest(resource, Method.GET);

			//request.RequestFormat = DataFormat.Json;
			//request.AddParameter("Accept", "application/json", ParameterType.HttpHeader);

			request.AddHeader("X-Auth-Token", authToken);
			request.AddHeader("X-Auth-Client", authClient);

			var response = client.Execute(request);
			var responseContent = response.Content;
			

			var webRequest = WebRequest.Create(baseUri + resource);
			webRequest.Headers.Add("X-Auth-Token", authToken);
			webRequest.Headers.Add("X-Auth-Client", authClient);

			var webResponse = webRequest.GetResponse();
			var webresponseDataStream = webResponse.GetResponseStream();
			var webResponseReader = new StreamReader(webresponseDataStream);
			var webResponseContent = webResponseReader.ReadToEnd();


			Assert.AreEqual(responseContent, webResponseContent);


		}
		
	}
}
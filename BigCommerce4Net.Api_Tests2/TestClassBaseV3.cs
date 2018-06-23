using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BigCommerce4Net.Api_Tests2
{
	public class TestClassBaseV3
	{
		public Api.ClientV3 Client { get; set; }
		public Api.Configuration Api_Configuration { get; set; }
		public const int TEST_ORDER_ID = 200;
		public const int TEST_CUSTOMER_ID = 6;
		public const int TEST_PRODUCT_ID = 200;
		public const int TEST_STATE_ID = 22;
		public const int TEST_COUNTRY_ID = 226;
		public const int TEST_COUPON_ID = 1;

		[TestInitialize]
		public void SetClient()
		{
			SetupContext();
			Client = new Api.ClientV3(this.Api_Configuration);
		}

		protected void SetupContext()
		{

			var settings = LoadJson();

			Api_Configuration = new Api.Configuration()
			{
				ServiceURL = settings.ServiceURL,
				UserName = settings.UserName,
				UserApiKey = settings.UserApiKey,
				AuthenticationType = settings.AuthenticationType,
				ApiVersion = settings.ApiVersion
			};

		}
		private TestSettings LoadJson()
		{

			TestSettings settings = null;

			if (File.Exists("TEST_SETTINGS.json"))
			{

				using (StreamReader r = new StreamReader("TEST_SETTINGS.json"))
				{
					string json = r.ReadToEnd();
					settings = JsonConvert.DeserializeObject<TestSettings>(json);
				}
			}
			else
			{

				settings = new TestSettings
				{
					ServiceURL = "https://--yourstore--/api/v2",
					UserName = "--Your User Name--",
					UserApiKey = "--Your Api Key--"
				};
			}

			//      Just add the file "TEST_SETTINGS.json" to your project, with your settings in the json below, set copy to output and you should be good to go.

			//      {
			//          'ServiceURL': 'https://--yourstore--/api/v2',
			//          'UserName': '--Your User Name--',
			//          'UserApiKey': '--Your Api Key--'
			//      }

			//      *** Just make sure TEST_SETTINGS.json is in your .gitignore file ***

			return settings;
		}

	}
}
#region License
//   Copyright 2013 Ken Worst - R.C. Worst & Company Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api = BigCommerce4Net.Api;
using System.IO;
using Newtonsoft.Json;

namespace BigCommerce4Net.Api_Tests2
{
    public class TestClassBase
    {
        public Api.Client Client { get; set; }
        public Api.Configuration Api_Configuration { get; set; }
        public const int TEST_ORDER_ID = 200;
        public const int TEST_CUSTOMER_ID = 6;
        public const int TEST_PRODUCT_ID = 200;
        public const int TEST_STATE_ID = 22;
        public const int TEST_COUNTRY_ID = 226;
        public const int TEST_COUPON_ID = 1;

        [TestInitialize]
        public void SetClient() {
            SetupContext();
            Client = new Api.Client(this.Api_Configuration);
        }

        public void SetupContext() {

            var settings = LoadJson();

            Api_Configuration = new Api.Configuration() {
                ServiceURL = settings.ServiceURL,
                UserName = settings.UserName,
                UserApiKey = settings.UserApiKey,
				AuthenticationType = settings.AuthenticationType,
				ApiVersion = settings.ApiVersion
            };

        }
        private TestSettings LoadJson() {

            TestSettings settings = null;

            if (File.Exists("TEST_SETTINGS.json")) {

                using (StreamReader r = new StreamReader("TEST_SETTINGS.json")) {
                    string json = r.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<TestSettings>(json);
                }
            } else {

                settings = new TestSettings {
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

    public class TestSettings
    {
        public string ServiceURL { get; set; }
        public string UserName { get; set; }
        public string UserApiKey { get; set; }
		public BigCommerce4Net.Api.AuthenticationType AuthenticationType { get; set; }
		public BigCommerce4Net.Api.ApiVersion ApiVersion { get; set; }
    }
}

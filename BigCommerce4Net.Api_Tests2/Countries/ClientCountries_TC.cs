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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api = BigCommerce4Net.Api;
using Domain = BigCommerce4Net.Domain;

namespace BigCommerce4Net.Api_Tests2.Countries
{
    [TestClass]
    public class ClientCountries_TC : TestClassBase
    {
        [TestMethod]
        public void Can_Get_Count() {

            var response = Client.Countries.Count();
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.IsTrue(response.Result.Count > 0);
        }
        [TestMethod]
        public void Can_Get_All_Countries_Default_Paging() {

            var response = Client.Countries.Get();
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(response.Result.Count, 50);
        }
        [TestMethod]
        public void Can_Get_All_Countries_With_Limit_Parameter_Paging() {
            var filter = new Api.FilterCountries
            {
                Limit = 200
            };

            var response = Client.Countries.Get(filter);
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreEqual(response.Result.Count, 200);
        }

        [TestMethod]
        public void Can_Get_One_Country_By_Id() {

            var response = Client.Countries.Get(TEST_COUNTRY_ID);
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.IsNotNull(response.Result);
            Assert.AreEqual(response.Result.Id, TEST_COUNTRY_ID);
        }
        [TestMethod]
        public void Can_Get_All_Countries_With_Paging() {

            var response = Client.Countries.GetList();
            Assert.IsTrue(response.Count > 50);
        }

        [TestMethod]
        public void Can_Get_Countries_GetHttpOptions() {

            var response = Client.Countries.GetHttpOptions();
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreNotEqual(response.Result, null);
        }
    }
}

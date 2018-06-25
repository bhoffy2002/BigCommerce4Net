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

namespace BigCommerce4Net.Api_Tests2.Products
{
    [TestClass]
    public class ClientProductsVideo_TC : TestClassBase
    {
        [TestMethod]
        public void Can_Get_GetHttpOptions() {

            var response = Client.ProductsVideo.GetHttpOptions(TEST_PRODUCT_ID);
            Assert.AreEqual(response.RestResponse.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.AreNotEqual(response.Result, null);
        }
    }
}
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
using RestSharp;
using Newtonsoft.Json;
using System.Net;

namespace BigCommerce4Net.Api
{
    public abstract class ClientBase
    {
	    protected string resourceEndpoint_base { get; set; }
	    protected string resourceEndpoint_id => resourceEndpoint_base + "/" + (resourceEndpoint_base.Contains("{0}") ? "{1}" : "{0}");
	    protected string resourceEndpoint_count => resourceEndpoint_base + "/count";

		private readonly Configuration _configuration;

		private static AuthenticationType _authType;

	    private static int _throttlingLimit;

        protected ClientBase(Configuration configuration) {
            configuration.AreConfigurationSet();
            this._configuration = configuration;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			_authType = configuration.AuthenticationType;
	        _throttlingLimit = GetThrottlingLimit();
        }
        protected IClientResponse<T> Count<T>(string resourceEndpoint)
            where T : new() {
                return Count<T>(resourceEndpoint, null);
        }

        protected IClientResponse<T> Count<T>(string resourceEndpoint, IFilter filter)
            where T :  new() {

            var request = new RestRequest(resourceEndpoint);
	        filter?.AddFilter(request);

	        var response = RestGet<T>(request);

            var clientResponse = new ClientResponse<T>() {
                RestResponse = response,
            };

            if (response.Data != null) {
                clientResponse.Result = response.Data;
            }

            DeserializeErrorData<T>(clientResponse);
            return clientResponse as IClientResponse<T>;
        }
        protected IClientResponse<T> GetData<T>(string resourceEndpoint)
            where T : new() {
            return GetData<T>(resourceEndpoint, null);
        }

        protected IClientResponse<T> GetData<T>(string resourceEndpoint, IFilter filter)
            where T : new() {
            var request = new RestRequest(resourceEndpoint);

	        filter?.AddFilter(request);

	        var response = RestGet<T>(request);

            var clientResponse = new ClientResponse<T>() {
                RestResponse = response,
            };
            if (response.Data != null) {
                clientResponse.Result = response.Data;
            }

            DeserializeErrorData<T>(clientResponse);
            return (IClientResponse<T>)clientResponse;
        }

        protected IClientResponse<T> PutData<T>(string resourceEndpoint, string json)
            where T : new() {
            var request = new RestRequest(resourceEndpoint);

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = RestPut<T>(request);

            var clientResponse = new ClientResponse<T>() {
                RestResponse = response,
                Result = response.Data
            };

            DeserializeErrorData<T>(clientResponse);
            return clientResponse;
        }

        protected IClientResponse<T> PostData<T>(string resourceEndpoint, string json)
            where T : new() {
            var request = new RestRequest(resourceEndpoint);

            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = RestPost<T>(request);

            var clientResponse = new ClientResponse<T>() {
                RestResponse = response,
                Result = response.Data
            };

            DeserializeErrorData<T>(clientResponse);
            return clientResponse;
        }
        protected IClientResponse<bool> DeleteData(string resourceEndpoint) {

            IClientResponse<bool> clientResponse = null;

            //Just making sure you want to delete data --just for little extra safety
            if (_configuration.AllowDeletions) {

                var request = new RestRequest(resourceEndpoint);

                var response = RestDelete<object>(request);

                clientResponse = new ClientResponse<bool>() {
                    RestResponse = response,
                    Result = response.StatusCode == System.Net.HttpStatusCode.NoContent ? true : false
                };

            } else {
                clientResponse = new ClientResponse<bool>() {
                    RestResponse = null,
                    Result =  false
                };
            }
            DeserializeErrorData<bool>(clientResponse);
            return clientResponse;
        }
        protected IClientResponse<T> GetHttpOptionsData<T>(string resourceEndpoint)
            where T : new() {
            var request = new RestRequest(resourceEndpoint);

            var response = RestOptions<T>(request);

            var clientResponse = new ClientResponse<T>() {
                RestResponse = response,
                Result = response.Data
            };

            DeserializeErrorData<T>(clientResponse);
            return clientResponse;
        }

        //Private Methods
        private void DeserializeErrorData<T>(IClientResponse<T> response) {

            if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.OK) return;
            if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.Created) return;
            if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.Accepted) return;
            if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.NoContent) return;
            
            try {
                response.ResponseErrors = JsonConvert.DeserializeObject<List<Domain.Error>>(response.RestResponse.Content);
            } catch (JsonSerializationException ex) {
                Log.Warn("Trouble Deserialize Error Object", ex);
                throw;
            }
        }

        private IRestResponse<T> RestGet<T>(IRestRequest request) where T : new() {
            request.Method = Method.GET;

            var client = new RestClient(_configuration.ServiceURL);

            var response = RestExecute<T>(request, client);

            return response;
        }
        private IRestResponse<T> RestPut<T>(IRestRequest request) where T : new() {
            request.Method = Method.PUT;

            var client = new RestClient(_configuration.ServiceURL);

            var response = RestExecute<T>(request, client);

            return response;
        }
        private IRestResponse<T> RestPost<T>(IRestRequest request) where T : new() {
            request.Method = Method.POST;

            var client = new RestClient(_configuration.ServiceURL);

            var response = RestExecute<T>(request, client);

            return response;
        }
        private IRestResponse<T> RestDelete<T>(IRestRequest request) where T : new() {
            request.Method = Method.DELETE;
            
            var client = new RestClient(_configuration.ServiceURL);

            var response = RestExecute<T>(request, client);

            return response;
        }
        private IRestResponse<T> RestOptions<T>(IRestRequest request) where T : new() {
            request.Method = Method.OPTIONS;

            var client = new RestClient(_configuration.ServiceURL);

            var response = RestExecute<T>(request, client);

            return response;
        }



        private IRestResponse<T> RestExecute<T>(IRestRequest request, IRestClient restClient) where T : new() {

            request.RequestFormat = DataFormat.Json;
            request.AddParameter("Accept", "application/json", ParameterType.HttpHeader);
            request.AddParameter("User-Agent", _configuration.UserAgent, ParameterType.HttpHeader);


            ((RestClient)restClient).AddHandler("application/json", new Deserializers.NewtonSoftJsonDeserializer());
            
            var client = restClient;
			if(_configuration.AuthenticationType == AuthenticationType.BasicAuthentication)
				client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(_configuration.UserName, _configuration.UserApiKey);
			else
				client.Authenticator = new BigcommerceOAuthAuthenticator(_configuration.UserApiKey, _configuration.UserName);
			client.Timeout = _configuration.RequestTimeout;

            var response = client.Execute<T>(request);

            CheckForThrottling(response);

            return response;
        }
        private void CheckForThrottling(IRestResponse response) {
	        if (_configuration.RequestThrottling != true) return;
	        var head = GetApiLimitRemaining(response);
	        if (head == null) return;
	        var wasParsed = int.TryParse(head.Value.ToString(), out var limitvalue);
	        if (!wasParsed) return;
	        if (limitvalue > _throttlingLimit) return;
	        Log.WarnFormat("------ Throttling Enabled Until Request Limit Gets About {0} ------", _throttlingLimit );
	        System.Threading.Thread.Sleep(_configuration.RequestThrottlingDelay);
        }

	    private int GetThrottlingLimit()
	    {
		    return _authType.Equals(AuthenticationType.BasicAuthentication)
			    ? _configuration.BasicAuthThrottleLimit
			    : _configuration.OAuthThrottleLimit;
	    }

        protected static void ShowIdAndApiLimit(object id, IRestResponse restResponse) {
            var apiLimit = GetApiLimitRemainingValue(restResponse);
            Log.InfoFormat("Id {0} -- API Limit: {1}", id, apiLimit);
        }
        


        protected void StatusCodeLogging(RestSharp.IRestResponse response, Type type) {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent) {
                Log.InfoFormat("[{0}] - Http Status Code: {1} - {2}", type.Name, (int)response.StatusCode, response.StatusDescription);
            }
            else {
                Log.ErrorFormat("[{0}] - Http Status Code: {1} - {2}", type.Name, (int)response.StatusCode, response.StatusDescription);
            }
        }


        protected List<T> RecordPaging<T>(IFilter filter, IParentResourcePaging<T> client)
        {
            List<T> items = new List<T>();

            int itemsCount = 0;
            int pageCount = 0;
            int remainingCount = 0;
            int recordsPerPage;

            if (_configuration.RecordsPerPage > _configuration.MaxPageLimit)
                recordsPerPage = _configuration.MaxPageLimit;
            else
                recordsPerPage = _configuration.RecordsPerPage;

            itemsCount = ((Domain.ItemCount)client.Count(filter).Result).Count;
            pageCount = itemsCount / recordsPerPage;
            remainingCount = itemsCount % recordsPerPage;

            for (int i = 1; i <= pageCount; i++) {
                filter.Page = i;
                filter.Limit = recordsPerPage;

                int retrys = 0;
                do {
                    var response = client.Get(filter);
                    if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.OK && response.Result != null) {
                        
                        items.AddRange(response.Result as List<T>);
                        Log.Info(GetPagingStatus(response.RestResponse, filter.Page, items.Count));
                        retrys = int.MaxValue;
                    }
                    else {
                        retrys++;
                        Log.ErrorFormat(GetErrorStatus(response.RestResponse));
                        System.Threading.Thread.Sleep(_configuration.ErrorRetryDelay);
                    }

                } while (retrys <= _configuration.ErrorRetryMax);
                
                if (retrys != int.MaxValue) {
                    throw new HttpServerException("Http Server not responding after retries");
                }
                

            }
            if (remainingCount > 0) {
                filter.Page = pageCount + 1;
                filter.Limit = recordsPerPage;

                int retrys = 0;
                do {
                    var response = client.Get(filter);
                    if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.OK && response.Result != null) {

                        items.AddRange(response.Result as List<T>);

                        Log.Info(GetPagingStatus(response.RestResponse, filter.Page, items.Count));
                        retrys = int.MaxValue;
                    }
                    else {
                        retrys++;
                        Log.ErrorFormat(GetErrorStatus(response.RestResponse));
                        System.Threading.Thread.Sleep(_configuration.ErrorRetryDelay);
                    }

                } while (retrys <= _configuration.ErrorRetryMax);

                if (retrys != int.MaxValue) {
                    throw new HttpServerException("Http Server not responding after retries");
                }
            }
            return items;
        }

		protected List<T> RecordPaging<T>(int id, IFilter filter, IChildResourcePaging<T> client)
		{
			//May Require More api calls then needed becasue doesn't use a call to count to get total number of items
			List<T> items = new List<T>();

			//int itemsCount = 0;
			//int pageCount = 0;
			//int remainingCount = 0;

			int recordsPerPage;

			int currentPageItemCount = 0;
			int pageNumber = 1;

			if (_configuration.RecordsPerPage > _configuration.MaxPageLimit)
				recordsPerPage = _configuration.MaxPageLimit;
			else
				recordsPerPage = _configuration.RecordsPerPage;

			if (filter == null)
				filter = new Filter();

			//itemsCount = ((Domain.ItemCount)client.Count(productid, filter).Result).Count;
			//pageCount = itemsCount / recordsPerPage;
			//remainingCount = itemsCount % recordsPerPage;


			do
			{
				//filter.Page = pageNumber;
				filter.Page = pageNumber > 1 ? pageNumber : (Nullable<int>)null;
				filter.Limit = recordsPerPage;

				int retrys = 0;
				do
				{
					currentPageItemCount = 0;
					var response = client.Get(id, filter);
					if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.OK && response.Result != null)
					{

						items.AddRange(response.Result as List<T>);
						Log.Info(GetPagingStatus(response.RestResponse, filter.Page, items.Count));
						retrys = int.MaxValue;
						currentPageItemCount = response.Result.Count;
					}
					else if ((int)response.RestResponse.StatusCode == 429 || (int)response.RestResponse.StatusCode == 509)
					{
						retrys++;
						Log.ErrorFormat(GetErrorStatus(response.RestResponse));
						System.Threading.Thread.Sleep(_configuration.ErrorRetryDelay);
					}
					else
					{
						Log.Info(ApendApiLimitToMessage(response.RestResponse, "Page {0} Status Returned: {1}", pageNumber, response.RestResponse.StatusCode));
						retrys = int.MaxValue;
					}


				} while (retrys <= _configuration.ErrorRetryMax);

				if (retrys != int.MaxValue)
				{
					throw new HttpServerException("Http Server not responding after retries");
				}

				pageNumber++;

			} while (currentPageItemCount >= recordsPerPage);

			//if (remainingCount > 0)
			//{
			//    filter.Page = pageCount + 1;
			//    filter.Limit = recordsPerPage;

			//    int retrys = 0;
			//    do
			//    {
			//        var response = client.Get(productid, filter);
			//        if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.OK && response.Result != null)
			//        {

			//            items.AddRange(response.Result as List<T>);

			//            log.Info(GetPagingStatus(response.RestResponse, filter.Page, items.Count));
			//            retrys = int.MaxValue;
			//        }
			//        else
			//        {
			//            retrys++;
			//            log.ErrorFormat(GetErrorStatus(response.RestResponse));
			//            System.Threading.Thread.Sleep(_Configuration.ErrorRetryDelay);
			//        }

			//    } while (retrys <= _Configuration.ErrorRetryMax);

			//    if (retrys != int.MaxValue)
			//    {
			//        throw new HttpServerException("Http Server not responding after retries");
			//    }
			//}
			return items;
		}

		private static string GetErrorStatus(RestSharp.IRestResponse response) {
            string str = string.Format("Http Status Code: {0} - {1} URL: {2}",
                            (int)response.StatusCode,
                            response.StatusDescription,
                            response.ResponseUri.AbsoluteUri);
            return str;
        }
        private static string GetPagingStatus(RestSharp.IRestResponse response, int? page, int count) {
            if (page == null) {
                page = 0;
            }
            var str = string.Format("Page {0} Record Count {1} -- API Limit: {2}", page, count, GetApiLimitRemainingValue(response));

            return str;
        }

	    private static string ApendApiLimitToMessage(RestSharp.IRestResponse response, string msg, int? page = null, params object[] obj)
	    {
		    string str = page.HasValue ? string.Format(msg + " -- API Limit: {1}", page,
				    GetApiLimitRemaining(response)?.Value)
			    : string.Format(msg + " -- API Limit: {0}",
				    GetApiLimitRemaining(response)?.Value);

		    return str;
	    }

	    private static string ApendApiLimitToMessage(RestSharp.IRestResponse response, string msg, params object[] obj)
	    {
		    string str = string.Format(msg + " -- API Limit: {" + obj.Length + "}", obj,
			    GetApiLimitRemaining(response)?.Value);

		    return str;
	    }

		private static object GetApiLimitRemainingValue(RestSharp.IRestResponse response)
		{
			return GetApiLimitRemaining(response).Value;
		}

	    private static Parameter GetApiLimitRemaining(RestSharp.IRestResponse response)
	    {
		    return (_authType.Equals(AuthenticationType.BasicAuthentication)
				    ? response.Headers.Where(x => x.Name.ToUpper() == "X-BC-APILIMIT-REMAINING")
				    : response.Headers.Where(x => x.Name.ToUpper() == "X-RATE-LIMIT-REQUESTS-LEFT")
			    ).FirstOrDefault();

	    }

		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}

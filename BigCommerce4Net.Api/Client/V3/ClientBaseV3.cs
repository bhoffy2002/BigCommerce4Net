using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BigCommerce4Net.Domain.V3.Misc;
using Newtonsoft.Json;
using RestSharp;

namespace BigCommerce4Net.Api.V3
{
	public abstract class ClientBaseV3
	{
		protected string resourceEndpoint_base { get; set; }
		protected string resourceEndpoint_id => resourceEndpoint_base + "/" + (resourceEndpoint_base.Contains("{0}") ? "{1}" : "{0}");

		private readonly Configuration _configuration;

		private static AuthenticationType _authType;

		private static int _throttlingLimit;

		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
			(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected ClientBaseV3(Configuration configuration)
		{
			configuration.AreConfigurationSet();
			this._configuration = configuration;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			_authType = configuration.AuthenticationType;
			_throttlingLimit = GetThrottlingLimit();



		}

		protected IClientResponse<T> GetData<T>(string resourceEndpoint)
			where T : new()
		{
			return GetData<T>(resourceEndpoint, null);
		}

		protected IClientResponse<T> GetData<T>(string resourceEndpoint, IFilter filter)
			where T : new()
		{
			var request = new RestRequest(resourceEndpoint);

			filter?.AddFilter(request);

			var response = RestGet<T>(request);

			var clientResponse = new ClientResponse<T>()
			{
				RestResponse = response,
			};
			if (response.Data != null)
			{
				clientResponse.Result = response.Data;
			}

			DeserializeErrorData<T>(clientResponse);
			return clientResponse;
		}

		//protected IClientResponseListV3<T> GetList<T>(string resourceEndpoint)
		//	where T : new()
		//{
		//	return GetList<T>(resourceEndpoint, null);
		//}

		protected IClientResponseListV3<T> GetList<T>(string resourceEndpoint, IFilter filter = null)
			where T : new()
		{
			
			filter = filter ?? new Filter();

			filter.Limit = _configuration.MaxPageLimit;
			
			

			var clientResponse = new ClientResponseListV3<T>()
			{
				
				//Responses = response,
			};

			var allRecordsReceived = false;

			do
			{
				var request = new RestRequest(resourceEndpoint);
				filter?.AddFilter(request);

				var response = RestGet<BigCResult<T>>(request);

				//if (response.Data.Data != null)
				//{
				//	foreach (var record in response.Data.Data)
				//	{
				//		clientResponse.Data.Add(record);
				//	}
				//}

				var result = new BigCResult<T>
				{
					Data = response.Data.Data,
					Meta = response.Data.Meta
				};

				if (result.Meta?.Pagination == null)
				{
					//Error???
					allRecordsReceived = true;
				}
				else
				{
					if (result.Meta.Pagination.CurrentPage < result.Meta.Pagination.TotalPages)
					{
						filter.Page = result.Meta.Pagination.CurrentPage + 1;
					}
					else
					{
						allRecordsReceived = true;
					}
				}
				
				clientResponse.Responses.Add(new ClientResponse<BigCResult<T>>
				{
					RestResponse = response,
					Result = result
				});

			} while (!allRecordsReceived);

			//Fill List from responses
			foreach (var resp in clientResponse.Responses)
			{
				foreach (var record in resp.Result.Data)
				{
					clientResponse.Data.Add(record);
				}
			}

			
			DeserializeErrorData<T>(clientResponse);
			return clientResponse;
		}
		
		protected IClientResponse<T> PutData<T>(string resourceEndpoint, string json)
			where T : new()
		{
			var request = new RestRequest(resourceEndpoint);

			request.AddParameter("application/json", json, ParameterType.RequestBody);

			var response = RestPut<T>(request);

			var clientResponse = new ClientResponse<T>()
			{
				RestResponse = response,
				Result = response.Data
			};

			DeserializeErrorData<T>(clientResponse);
			return clientResponse;
		}

		protected IClientResponse<T> PostData<T>(string resourceEndpoint, string json)
			where T : new()
		{
			var request = new RestRequest(resourceEndpoint);

			request.AddParameter("application/json", json, ParameterType.RequestBody);

			var response = RestPost<T>(request);

			var clientResponse = new ClientResponse<T>()
			{
				RestResponse = response,
				Result = response.Data
			};

			DeserializeErrorData<T>(clientResponse);
			return clientResponse;
		}
		protected IClientResponse<bool> DeleteData(string resourceEndpoint)
		{

			IClientResponse<bool> clientResponse = null;

			//Just making sure you want to delete data --just for little extra safety
			if (_configuration.AllowDeletions)
			{

				var request = new RestRequest(resourceEndpoint);

				var response = RestDelete<object>(request);

				clientResponse = new ClientResponse<bool>()
				{
					RestResponse = response,
					Result = response.StatusCode == System.Net.HttpStatusCode.NoContent ? true : false
				};

			}
			else
			{
				clientResponse = new ClientResponse<bool>()
				{
					RestResponse = null,
					Result = false
				};
			}
			DeserializeErrorData<bool>(clientResponse);
			return clientResponse;
		}


		protected static void ShowIdAndApiLimit(object id, IRestResponse restResponse)
		{
			var apiLimit = GetApiLimitRemainingValue(restResponse);
			Log.InfoFormat("Id {0} -- API Limit: {1}", id, apiLimit);
		}



		protected void StatusCodeLogging(RestSharp.IRestResponse response, Type type)
		{
			if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
			{
				Log.InfoFormat("[{0}] - Http Status Code: {1} - {2}", type.Name, (int)response.StatusCode, response.StatusDescription);
			}
			else
			{
				Log.ErrorFormat("[{0}] - Http Status Code: {1} - {2}", type.Name, (int)response.StatusCode, response.StatusDescription);
			}
		}

		//Private Methods
		private void DeserializeErrorData<T>(IClientResponse<T> response)
		{

			if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.OK) return;
			if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.Created) return;
			if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.Accepted) return;
			if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.NoContent) return;

			try
			{
				response.ResponseErrors = JsonConvert.DeserializeObject<List<Domain.Error>>(response.RestResponse.Content);
			}
			catch (JsonSerializationException ex)
			{
				Log.Warn("Trouble Deserialize Error Object", ex);
				throw;
			}
		}

		private void DeserializeErrorData<T>(IClientResponseList<T> response)
		{

			if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.OK) return;
			if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.Created) return;
			if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.Accepted) return;
			if (response.RestResponse.StatusCode == System.Net.HttpStatusCode.NoContent) return;

			try
			{
				response.ResponseErrors = JsonConvert.DeserializeObject<List<Domain.Error>>(response.RestResponse.Content);
			}
			catch (JsonSerializationException ex)
			{
				Log.Warn("Trouble Deserialize Error Object", ex);
				throw;
			}
		}

		private void DeserializeErrorData<T>(IClientResponseListV3<T> response)
		{
			foreach (var resp in response.Responses)
			{
				switch (resp.RestResponse.StatusCode)
				{
					case System.Net.HttpStatusCode.OK:
					case System.Net.HttpStatusCode.Created:
					case System.Net.HttpStatusCode.Accepted:
					case System.Net.HttpStatusCode.NoContent:
						return;
				}

				try
				{
					resp.ResponseErrors = JsonConvert.DeserializeObject<List<Domain.Error>>(resp.RestResponse.Content);
				}
				catch (JsonSerializationException ex)
				{
					Log.Warn("Trouble Deserialize Error Object", ex);
					throw;
				}

			}
		}

		private IRestResponse<T> RestGet<T>(IRestRequest request) where T : new()
		{
			request.Method = Method.GET;

			var client = new RestClient(_configuration.ServiceURL);

			var response = RestExecute<T>(request, client);

			return response;
		}
		
		private IRestResponse<T> RestPut<T>(IRestRequest request) where T : new()
		{
			request.Method = Method.PUT;

			var client = new RestClient(_configuration.ServiceURL);

			var response = RestExecute<T>(request, client);

			return response;
		}
		private IRestResponse<T> RestPost<T>(IRestRequest request) where T : new()
		{
			request.Method = Method.POST;

			var client = new RestClient(_configuration.ServiceURL);

			var response = RestExecute<T>(request, client);

			return response;
		}
		private IRestResponse<T> RestDelete<T>(IRestRequest request) where T : new()
		{
			request.Method = Method.DELETE;

			var client = new RestClient(_configuration.ServiceURL);

			var response = RestExecute<T>(request, client);

			return response;
		}

		private IRestResponse<T> RestExecute<T>(IRestRequest request, IRestClient restClient) where T : new()
		{

			request.RequestFormat = DataFormat.Json;
			request.AddParameter("Accept", "application/json", ParameterType.HttpHeader);
			request.AddParameter("User-Agent", _configuration.UserAgent, ParameterType.HttpHeader);


			((RestClient)restClient).AddHandler("application/json", new Deserializers.NewtonSoftJsonDeserializer());

			var client = restClient;
			if (_configuration.AuthenticationType == AuthenticationType.BasicAuthentication)
				client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(_configuration.UserName, _configuration.UserApiKey);
			else
				client.Authenticator = new BigcommerceOAuthAuthenticator(_configuration.UserApiKey, _configuration.UserName);
			client.Timeout = _configuration.RequestTimeout;

			var response = client.Execute<T>(request);

			CheckForThrottling(response);

			return response;
		}

		private void CheckForThrottling(IRestResponse response)
		{
			if (_configuration.RequestThrottling != true) return;
			var head = GetApiLimitRemaining(response);
			if (head == null) return;
			var wasParsed = int.TryParse(head.Value.ToString(), out var limitvalue);
			if (!wasParsed) return;
			if (limitvalue > _throttlingLimit) return;
			Log.WarnFormat("------ Throttling Enabled Until Request Limit Gets About {0} ------", _throttlingLimit);
			System.Threading.Thread.Sleep(_configuration.RequestThrottlingDelay);
		}

		private int GetThrottlingLimit()
		{
			return _authType.Equals(AuthenticationType.BasicAuthentication)
				? _configuration.BasicAuthThrottleLimit
				: _configuration.OAuthThrottleLimit;
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

		private static string GetErrorStatus(RestSharp.IRestResponse response)
		{
			string str = string.Format("Http Status Code: {0} - {1} URL: {2}",
				(int)response.StatusCode,
				response.StatusDescription,
				response.ResponseUri.AbsoluteUri);
			return str;
		}

	}
}
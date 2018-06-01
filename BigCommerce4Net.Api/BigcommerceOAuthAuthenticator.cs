using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace BigCommerce4Net.Api
{
	public class BigcommerceOAuthAuthenticator : RestSharp.Authenticators.OAuth2Authenticator
	{
		/// <summary>
		/// ClientId to be used when authenticating
		/// </summary>
		private readonly string clientId;

		public string ClientId => clientId;

		public BigcommerceOAuthAuthenticator(string accessToken, string clientId) : base(accessToken)
		{
			this.clientId = clientId;
		}

		public override void Authenticate(IRestClient client, IRestRequest request)
		{
			request.AddHeader("X-Auth-Token", AccessToken);
			request.AddHeader("X-Auth-Client", ClientId);
		}
	}
}

using System;
using System.Configuration;
using System.Linq;
using Flurl.Http;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ServiceManager
{
	public class AccountValidator
	{
		private static string apiUrl = ConfigurationManager.AppSettings["TestApiUrl"];
		public static async Task<HttpResponseMessage> SendValidationRequest(string bankAccount, string authKey, bool isTokenEmpty = false)
		{
			var validationUrl = apiUrl + "/api/v3/validate/bank-account";
			var reguestBody = new { bankAccount = bankAccount };
			var headers = new Dictionary<string, object>();
			headers.Add("Content-Type", "application/json");

			if (!isTokenEmpty)
				headers.Add("X-Auth-Key", authKey);
			var result = await validationUrl.AllowHttpStatus("400-404,6xx")
				  .WithHeaders(headers)
				  .PostJsonAsync(reguestBody);
			
			Console.WriteLine($"Sending request to uri: {result.RequestMessage.RequestUri}");
			Console.WriteLine($"RequestHeaders: {result.RequestMessage.Headers}");
			Console.WriteLine($"RequestBody: {reguestBody}");
			Console.WriteLine($"Request result: {result.StatusCode}");
			return result;
		}

		public static async Task<TResponse> GetResponseBody<TResponse>(HttpResponseMessage rawResponse)			
		{
			var rawResponseAsString = await rawResponse.Content.ReadAsStringAsync();
			Console.WriteLine($"Raw responseBody: {rawResponseAsString}");
			var responseBody = JsonConvert.DeserializeObject<TResponse>(rawResponseAsString);
			Console.WriteLine($"Serialized responseBody: {JsonConvert.SerializeObject(responseBody)}");
			return responseBody;
		}
	}
}

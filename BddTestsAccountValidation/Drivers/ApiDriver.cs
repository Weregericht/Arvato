using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using ServiceManager;
using ServiceManager.Entities;

namespace BddTestsAccountValidation.Drivers
{
	public class ApiDriver
	{	
		public HttpResponseMessage _httpResponseMessage;
		public HttpStatusCode _resultCode;

		public async Task ValidateAccount(string baseUri, string account, string validAuthToken, bool isTokenEmpty)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			_httpResponseMessage = await AccountValidator.SendValidationRequest(account, validAuthToken, isTokenEmpty);		
		}

		public void CheckResponseStatusCode(HttpStatusCode expectedStatusCode)
		{
			_httpResponseMessage.StatusCode.Should().Be(expectedStatusCode);
		}

	}
}

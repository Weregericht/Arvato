using Newtonsoft.Json;
using ServiceManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataGenerators.ExpectedObjects
{
	public static class ExpectedResponseGenerator
	{
		public static object GetValidAccountResponse()
		{
			var expectedResponse = new
			{
				IsValid = true,
				RiskCheckMessages = (RiskCheckMessage)null
			};
			Console.WriteLine($"Prepare expected response: {JsonConvert.SerializeObject(expectedResponse)}");
			return expectedResponse;
		}

		public static object GetInvalidAccountResponseArray(string actionCode, string type, string errorCode, string message, string fieldReference = "bankAccount")
		{
			var expectedResponse = new[] 
			{
				new
				{
					ActionCode = actionCode,
					Code = type,
					Message = message,
					FieldReference = fieldReference,
					Type = type
				}
			};
			Console.WriteLine($"Prepare expected response: {JsonConvert.SerializeObject(expectedResponse)}");
			return expectedResponse;
		}


		public static object GetInvalidAuthorizationResponse(string expectedMessage)
		{
			var expectedResponse = new
			{
				Message = "Authorization has been denied for this request."
			};
			Console.WriteLine($"Prepare expected response: {JsonConvert.SerializeObject(expectedResponse)}");
			return expectedResponse;
		}
	}
}

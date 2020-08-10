using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataGenerators;
using DataGenerators.Dictionaries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceManager;
using ServiceManager.Entities;
using FluentAssertions;
using DataGenerators.ExpectedObjects;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace ArvatoTest
{
	[TestClass]
	public class BankAccountTests
	{
		private string validAuthToken = ConfigurationManager.AppSettings["ValidAuthToken"];
		[TestMethod]
		public async Task TestValidAustriaAccount()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetValidAccountResponse();
			var account = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Austria);
			var result = await AccountValidator.SendValidationRequest(account, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<ValidAccountResponse>(result);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestValidGermanyAccount()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetValidAccountResponse();
			var account = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Germany);
			var result = await AccountValidator.SendValidationRequest(account, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<ValidAccountResponse>(result);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestValidDenmarkAccount()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetValidAccountResponse();
			var account = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Denmark);
			var result = await AccountValidator.SendValidationRequest(account, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<ValidAccountResponse>(result);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestValidFinlandAccount()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetValidAccountResponse();
			var account = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Finland);
			var result = await AccountValidator.SendValidationRequest(account, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<ValidAccountResponse>(result);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestValidNorwayAccount()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetValidAccountResponse();
			var account = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Norway);
			var result = await AccountValidator.SendValidationRequest(account, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<ValidAccountResponse>(result);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestValidSwedenAccount()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetValidAccountResponse();
			var account = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Sweden);
			var result = await AccountValidator.SendValidationRequest(account, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<ValidAccountResponse>(result);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestValidSwitzerlandAccount()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetValidAccountResponse();
			var account = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Switzerland);
			var result = await AccountValidator.SendValidationRequest(account, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<ValidAccountResponse>(result);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestValidOtherCountryAccount()
		{
			var expectedResponseBody =
				ExpectedResponseGenerator.GetInvalidAccountResponseArray(ActionCode.AskConsumerToReEnterData.ToString(),
				ResponseType.BusinessError.ToString(),
				"400.005",
				"This country is not supported");
			var otherCountry = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.OtherCountry);
			var result = await AccountValidator.SendValidationRequest(otherCountry, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<InvalidAccountResponse>(result);

			Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestInvalidAccount()
		{
			var expectedResponseBody = 
				ExpectedResponseGenerator.GetInvalidAccountResponseArray(ActionCode.AskConsumerToReEnterData.ToString(), 
				ResponseType.BusinessError.ToString(), 
				"400.005", 
				"A string value exceeds maximum length of 34.");				
			var invalidAccount = IbanAccountGenerator.GetInvalidIbanAccount();
			var result = await AccountValidator.SendValidationRequest(invalidAccount, validAuthToken);
			var resultBody = await AccountValidator.GetResponseBody<List<InvalidAccountResponse>>(result);

			Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestInvalidAuthToken()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetInvalidAuthorizationResponse("Authorization has been denied for this request.");

			var austriaAccount = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Austria);
			var result = await AccountValidator.SendValidationRequest(austriaAccount, "sdf");
			var resultBody = await AccountValidator.GetResponseBody<InvalidAuthenticationResponse>(result);

			Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}

		[TestMethod]
		public async Task TestEmptyAuthToken()
		{
			var expectedResponseBody = ExpectedResponseGenerator.GetInvalidAuthorizationResponse("Authorization has been denied for this request.");

			var austriaAccount = IbanAccountGenerator.GetValidIbanAccountForCountry(AvailableCountries.Austria);
			var result = await AccountValidator.SendValidationRequest(austriaAccount, null, true);
			var resultBody = await AccountValidator.GetResponseBody<InvalidAuthenticationResponse>(result);

			Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode);
			resultBody.ShouldBeEquivalentTo(expectedResponseBody, o => o.RespectingRuntimeTypes());
		}
	}
}

using BddTestsAccountValidation.Drivers;
using DataGenerators.Dictionaries;
using DataGenerators.ExpectedObjects;
using FluentAssertions;
using ServiceManager;
using ServiceManager.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ArvatoTest.Steps
{
	[Binding]
	public sealed class IbanValidationSteps
	{
		private readonly ApiDriver _apiDriver;

		public IbanValidationSteps(ApiDriver apiDriver)
		{
			_apiDriver = apiDriver;
		}

		public HttpResponseMessage _result;
		public object _responseBody;
		public object _expectedResponseBody;
		public string _account;
		public bool _isTokenEmpty = false;
		public string _authToken;

		[Given("country: (.*) for bank account")]
		public void GivenBankAccountIs(AvailableCountries country)
		{
			_account = DataGenerators.IbanAccountGenerator.GetValidIbanAccountForCountry(country);
		}

		[Given("invalid bank account")]
		public void GivenInvalidBankAccount()
		{
			_account = DataGenerators.IbanAccountGenerator.GetInvalidIbanAccount();
		}

		[Given("JWT token (.*)")]
		public void GivenAuthToken(string token)
		{
			_authToken = token;
		}

		[Given("empty JWT token")]
		public void GivenEmptyAuthToken()
		{
			_isTokenEmpty = true;
		}

		[Given("expected response object:")]
		public void GivenExpectedObject(Table values)
		{
			var table = values.CreateInstance<ResponseTable>();
			switch (table.ResultCode)
			{
				case ResultTypes.Success:
					_expectedResponseBody = ExpectedResponseGenerator.GetValidAccountResponse();
					break;
				case ResultTypes.InvalidAccount:
					_expectedResponseBody = ExpectedResponseGenerator.GetInvalidAccountResponseArray(table.ActionCode,
								table.Type,
								table.ErrorCode,
								table.Message);
					break;
				case ResultTypes.InvalidAuthentification:
					_expectedResponseBody = ExpectedResponseGenerator.GetInvalidAuthorizationResponse(table.Message);
					break;
			}
		}

		[When("request was sended")]
		public async Task WhenRequestWasSended()
		{
			await _apiDriver.ValidateAccount("https://api-test.afterpay.dev", _account, _authToken, _isTokenEmpty);			
		}

		[Then("the status code should be (.*)")]
		public void ThenTheResultShouldBe(HttpStatusCode resultCode)
		{
			_apiDriver.CheckResponseStatusCode(resultCode);
		}

		[Then("response body should be equivqlent to expected (.*) object")]
		public async Task ThenTheBodyShouldBeEqualExp(ResultTypes expectedResultType)
		{
			switch (expectedResultType)
			{
				case ResultTypes.Success:
					_responseBody = await AccountValidator.GetResponseBody<ValidAccountResponse>(_apiDriver._httpResponseMessage);
					break;
				case ResultTypes.InvalidAccount:
					_responseBody = await AccountValidator.GetResponseBody<List<InvalidAccountResponse>>(_apiDriver._httpResponseMessage);
					break;
				case ResultTypes.InvalidAuthentification:
					_responseBody = await AccountValidator.GetResponseBody<InvalidAuthenticationResponse>(_apiDriver._httpResponseMessage);
					break;
			}
			_responseBody.ShouldBeEquivalentTo(_expectedResponseBody, o => o.RespectingRuntimeTypes());
		}
	}
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ServiceManager.Entities
{
	public class ValidAccountResponse
	{
		[JsonProperty("isValid")]
		public bool IsValid { get; set; }
		[JsonProperty("riskCheckMessages")]
		public RiskCheckMessage[] RiskCheckMessages { get; set; }
	}
}

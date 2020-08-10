using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Entities
{
	public class RiskCheckMessage
	{
		[JsonProperty("actionCode")]
		public ActionCode ActionCode { get; set; }
		[JsonProperty("code")]
		public string Code { get; set; }
		[JsonProperty("fieldReference")]
		public string FieldReference { get; set; }
		[JsonProperty("message")]
		public string Message { get; set; }
		[JsonProperty("type")]
		public ResponseType Type { get; set; }
		[JsonProperty("customerFacingMessage")]
		public string CustomerFacingMessage { get; set; }
	}
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ServiceManager.Entities
{
	public class InvalidAuthenticationResponse 
	{
		[JsonProperty("Message")]
		public string Message { get; set; }
	}
}

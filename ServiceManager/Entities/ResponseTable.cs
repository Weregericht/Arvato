using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Entities
{
	public class ResponseTable
	{
		public ResultTypes ResultCode { get; set; }
		public string ActionCode { get; set; }
		public string Type { get; set; }
		public string ErrorCode { get; set; }
		public string Message { get; set; }
		public string FieldReference { get; set; } 
	}
}

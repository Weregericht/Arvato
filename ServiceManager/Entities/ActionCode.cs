using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.Entities
{
	public enum ActionCode
	{
		Unavailable,
		AskConsumerToConfirm,
		AskConsumerToReEnterData,
		OfferSecurePaymentMethods,
		RequiresSsn
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[MessageContract(IsWrapped = false)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public class SendReqResponse
	{
		public SendReqResponse()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public SendReqResponse(SendReqResponseBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "SendReqResponse", Namespace = "http://aisgorod.ru/", Order = 0)]
		public SendReqResponseBody Body;
	}
}

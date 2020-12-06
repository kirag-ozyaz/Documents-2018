using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[MessageContract(IsWrapped = false)]
	[DebuggerStepThrough]
	public class SendReqRequest
	{
		public SendReqRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public SendReqRequest(SendReqRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "SendReq", Namespace = "http://aisgorod.ru/", Order = 0)]
		public SendReqRequestBody Body;
	}
}

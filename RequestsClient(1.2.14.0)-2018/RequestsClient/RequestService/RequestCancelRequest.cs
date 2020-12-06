using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[MessageContract(IsWrapped = false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public class RequestCancelRequest
	{
		public RequestCancelRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public RequestCancelRequest(RequestCancelRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "RequestCancel", Namespace = "http://aisgorod.ru/", Order = 0)]
		public RequestCancelRequestBody Body;
	}
}

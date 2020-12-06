using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[MessageContract(IsWrapped = false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerStepThrough]
	public class RequestCancelResponse
	{
		public RequestCancelResponse()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public RequestCancelResponse(RequestCancelResponseBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "RequestCancelResponse", Namespace = "http://aisgorod.ru/", Order = 0)]
		public RequestCancelResponseBody Body;
	}
}

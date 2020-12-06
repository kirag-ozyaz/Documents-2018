using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[DebuggerStepThrough]
	[MessageContract(IsWrapped = false)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public class GetDictStatusResponse
	{
		public GetDictStatusResponse()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictStatusResponse(GetDictStatusResponseBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictStatusResponse", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictStatusResponseBody Body;
	}
}

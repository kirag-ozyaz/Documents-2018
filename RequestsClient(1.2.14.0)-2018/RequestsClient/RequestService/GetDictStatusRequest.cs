using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[DebuggerStepThrough]
	[MessageContract(IsWrapped = false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class GetDictStatusRequest
	{
		public GetDictStatusRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictStatusRequest(GetDictStatusRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictStatus", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictStatusRequestBody Body;
	}
}

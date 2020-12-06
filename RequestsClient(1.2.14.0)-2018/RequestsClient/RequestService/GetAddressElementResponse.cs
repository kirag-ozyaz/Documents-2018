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
	public class GetAddressElementResponse
	{
		public GetAddressElementResponse()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetAddressElementResponse(GetAddressElementResponseBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetAddressElementResponse", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetAddressElementResponseBody Body;
	}
}

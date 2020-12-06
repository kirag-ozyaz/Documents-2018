using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[MessageContract(IsWrapped = false)]
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public class GetAddressElementRequest
	{
		public GetAddressElementRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetAddressElementRequest(GetAddressElementRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetAddressElement", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetAddressElementRequestBody Body;
	}
}

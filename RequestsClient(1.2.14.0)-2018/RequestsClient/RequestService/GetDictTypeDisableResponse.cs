using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[MessageContract(IsWrapped = false)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class GetDictTypeDisableResponse
	{
		public GetDictTypeDisableResponse()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeDisableResponse(GetDictTypeDisableResponseBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictTypeDisableResponse", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictTypeDisableResponseBody Body;
	}
}

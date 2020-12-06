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
	public class GetDictTypeRegionResponse
	{
		public GetDictTypeRegionResponse()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeRegionResponse(GetDictTypeRegionResponseBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictTypeRegionResponse", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictTypeRegionResponseBody Body;
	}
}

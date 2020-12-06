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
	public class GetDictTypeRegionRequest
	{
		public GetDictTypeRegionRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeRegionRequest(GetDictTypeRegionRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictTypeRegion", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictTypeRegionRequestBody Body;
	}
}

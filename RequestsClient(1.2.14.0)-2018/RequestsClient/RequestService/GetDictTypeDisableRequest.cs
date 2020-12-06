using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[MessageContract(IsWrapped = false)]
	[DebuggerStepThrough]
	public class GetDictTypeDisableRequest
	{
		public GetDictTypeDisableRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeDisableRequest(GetDictTypeDisableRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictTypeDisable", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictTypeDisableRequestBody Body;
	}
}

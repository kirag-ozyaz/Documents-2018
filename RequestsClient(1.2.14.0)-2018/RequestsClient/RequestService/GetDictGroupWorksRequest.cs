using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[MessageContract(IsWrapped = false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class GetDictGroupWorksRequest
	{
		public GetDictGroupWorksRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictGroupWorksRequest(GetDictGroupWorksRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictGroupWorks", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictGroupWorksRequestBody Body;
	}
}

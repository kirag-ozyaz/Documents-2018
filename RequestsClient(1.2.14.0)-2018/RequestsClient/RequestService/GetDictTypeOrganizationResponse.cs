using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[MessageContract(IsWrapped = false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class GetDictTypeOrganizationResponse
	{
		public GetDictTypeOrganizationResponse()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeOrganizationResponse(GetDictTypeOrganizationResponseBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictTypeOrganizationResponse", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictTypeOrganizationResponseBody Body;
	}
}

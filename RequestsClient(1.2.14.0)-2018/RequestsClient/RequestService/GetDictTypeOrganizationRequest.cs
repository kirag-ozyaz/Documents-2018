using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[MessageContract(IsWrapped = false)]
	[DebuggerStepThrough]
	public class GetDictTypeOrganizationRequest
	{
		public GetDictTypeOrganizationRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeOrganizationRequest(GetDictTypeOrganizationRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "GetDictTypeOrganization", Namespace = "http://aisgorod.ru/", Order = 0)]
		public GetDictTypeOrganizationRequestBody Body;
	}
}

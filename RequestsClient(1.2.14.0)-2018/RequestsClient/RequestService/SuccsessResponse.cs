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
	public class SuccsessResponse
	{
		public SuccsessResponse()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public SuccsessResponse(SuccsessResponseBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "SuccsessResponse", Namespace = "http://aisgorod.ru/", Order = 0)]
		public SuccsessResponseBody Body;
	}
}

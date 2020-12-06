using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	[MessageContract(IsWrapped = false)]
	public class SuccsessRequest
	{
		public SuccsessRequest()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public SuccsessRequest(SuccsessRequestBody Body)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.Body = Body;
		}

		[MessageBodyMember(Name = "Succsess", Namespace = "http://aisgorod.ru/", Order = 0)]
		public SuccsessRequestBody Body;
	}
}

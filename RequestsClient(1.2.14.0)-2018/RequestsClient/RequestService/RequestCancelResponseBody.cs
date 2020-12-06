using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[DataContract(Namespace = "http://aisgorod.ru/")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class RequestCancelResponseBody
	{
		public RequestCancelResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public RequestCancelResponseBody(Response RequestCancelResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.RequestCancelResult = RequestCancelResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public Response RequestCancelResult;
	}
}

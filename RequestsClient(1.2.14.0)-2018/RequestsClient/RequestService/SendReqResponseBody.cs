using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DataContract(Namespace = "http://aisgorod.ru/")]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class SendReqResponseBody
	{
		public SendReqResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public SendReqResponseBody(Response SendReqResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.SendReqResult = SendReqResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public Response SendReqResult;
	}
}

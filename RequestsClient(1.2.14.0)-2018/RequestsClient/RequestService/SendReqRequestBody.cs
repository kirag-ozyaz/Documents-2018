using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerStepThrough]
	[DataContract(Namespace = "http://aisgorod.ru/")]
	public class SendReqRequestBody
	{
		public SendReqRequestBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public SendReqRequestBody(Request req)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.req = req;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public Request req;
	}
}

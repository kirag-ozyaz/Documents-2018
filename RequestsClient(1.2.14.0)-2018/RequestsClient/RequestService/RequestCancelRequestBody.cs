using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DataContract(Namespace = "http://aisgorod.ru/")]
	[DebuggerStepThrough]
	public class RequestCancelRequestBody
	{
		public RequestCancelRequestBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public RequestCancelRequestBody(long RequestId)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.RequestId = RequestId;
		}

		[DataMember(Order = 0)]
		public long RequestId;
	}
}

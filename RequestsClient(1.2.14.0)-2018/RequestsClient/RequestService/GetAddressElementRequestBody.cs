using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DataContract(Namespace = "http://aisgorod.ru/")]
	public class GetAddressElementRequestBody
	{
		public GetAddressElementRequestBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetAddressElementRequestBody(long? parentId)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.parentId = parentId;
		}

		[DataMember(Order = 0)]
		public long? parentId;
	}
}

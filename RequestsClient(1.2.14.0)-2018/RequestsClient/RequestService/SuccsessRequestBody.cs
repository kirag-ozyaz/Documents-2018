using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[DataContract(Namespace = "http://aisgorod.ru/")]
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public class SuccsessRequestBody
	{
		public SuccsessRequestBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public SuccsessRequestBody(long RequestId, DateTime DateEnd)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.RequestId = RequestId;
			this.DateEnd = DateEnd;
		}

		[DataMember(Order = 0)]
		public long RequestId;

		[DataMember(Order = 1)]
		public DateTime DateEnd;
	}
}

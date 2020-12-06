using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DataContract(Namespace = "http://aisgorod.ru/")]
	[DebuggerStepThrough]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public class SuccsessResponseBody
	{
		public SuccsessResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public SuccsessResponseBody(Response SuccsessResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.SuccsessResult = SuccsessResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public Response SuccsessResult;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[DataContract(Namespace = "http://aisgorod.ru/")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	public class GetDictStatusResponseBody
	{
		public GetDictStatusResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictStatusResponseBody(DICTIONARY[] GetDictStatusResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.GetDictStatusResult = GetDictStatusResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public DICTIONARY[] GetDictStatusResult;
	}
}

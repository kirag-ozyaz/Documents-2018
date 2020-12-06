using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[DataContract(Namespace = "http://aisgorod.ru/")]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DebuggerStepThrough]
	public class GetDictGroupWorksResponseBody
	{
		public GetDictGroupWorksResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictGroupWorksResponseBody(DICTIONARY[] GetDictGroupWorksResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.GetDictGroupWorksResult = GetDictGroupWorksResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public DICTIONARY[] GetDictGroupWorksResult;
	}
}

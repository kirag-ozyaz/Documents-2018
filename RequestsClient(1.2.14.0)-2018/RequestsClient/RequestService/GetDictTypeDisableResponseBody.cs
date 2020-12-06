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
	public class GetDictTypeDisableResponseBody
	{
		public GetDictTypeDisableResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeDisableResponseBody(DICTIONARY[] GetDictTypeDisableResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.GetDictTypeDisableResult = GetDictTypeDisableResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public DICTIONARY[] GetDictTypeDisableResult;
	}
}

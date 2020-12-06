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
	public class GetDictTypeRegionResponseBody
	{
		public GetDictTypeRegionResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeRegionResponseBody(DICTIONARY[] GetDictTypeRegionResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.GetDictTypeRegionResult = GetDictTypeRegionResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public DICTIONARY[] GetDictTypeRegionResult;
	}
}

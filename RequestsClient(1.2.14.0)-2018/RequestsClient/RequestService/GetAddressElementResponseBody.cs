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
	public class GetAddressElementResponseBody
	{
		public GetAddressElementResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetAddressElementResponseBody(AddressElement[] GetAddressElementResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.GetAddressElementResult = GetAddressElementResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public AddressElement[] GetAddressElementResult;
	}
}

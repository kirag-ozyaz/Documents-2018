using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace RequestsClient.RequestService
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[DebuggerStepThrough]
	[DataContract(Namespace = "http://aisgorod.ru/")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public class GetDictTypeOrganizationResponseBody
	{
		public GetDictTypeOrganizationResponseBody()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public GetDictTypeOrganizationResponseBody(DICTIONARY[] GetDictTypeOrganizationResult)
		{
			Class38.TqlX7ZmzmDDi2();
			
			this.GetDictTypeOrganizationResult = GetDictTypeOrganizationResult;
		}

		[DataMember(EmitDefaultValue = false, Order = 0)]
		public DICTIONARY[] GetDictTypeOrganizationResult;
	}
}

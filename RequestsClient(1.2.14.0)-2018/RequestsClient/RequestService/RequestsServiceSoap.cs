using System;
using System.CodeDom.Compiler;
using System.ServiceModel;

namespace RequestsClient.RequestService
{
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	[ServiceContract(Namespace = "http://aisgorod.ru/", ConfigurationName = "RequestService.RequestsServiceSoap")]
	public interface RequestsServiceSoap
	{
		[OperationContract(Action = "http://aisgorod.ru/Succsess", ReplyAction = "*")]
		SuccsessResponse Succsess(SuccsessRequest request);

		[OperationContract(Action = "http://aisgorod.ru/RequestCancel", ReplyAction = "*")]
		RequestCancelResponse RequestCancel(RequestCancelRequest request);

		[OperationContract(Action = "http://aisgorod.ru/SendReq", ReplyAction = "*")]
		SendReqResponse SendReq(SendReqRequest request);

		[OperationContract(Action = "http://aisgorod.ru/GetDictGroupWorks", ReplyAction = "*")]
		GetDictGroupWorksResponse GetDictGroupWorks(GetDictGroupWorksRequest request);

		[OperationContract(Action = "http://aisgorod.ru/GetDictTypeDisable", ReplyAction = "*")]
		GetDictTypeDisableResponse GetDictTypeDisable(GetDictTypeDisableRequest request);

		[OperationContract(Action = "http://aisgorod.ru/GetDictTypeRegion", ReplyAction = "*")]
		GetDictTypeRegionResponse GetDictTypeRegion(GetDictTypeRegionRequest request);

		[OperationContract(Action = "http://aisgorod.ru/GetDictStatus", ReplyAction = "*")]
		GetDictStatusResponse GetDictStatus(GetDictStatusRequest request);

		[OperationContract(Action = "http://aisgorod.ru/GetDictTypeOrganization", ReplyAction = "*")]
		GetDictTypeOrganizationResponse GetDictTypeOrganization(GetDictTypeOrganizationRequest request);

		[OperationContract(Action = "http://aisgorod.ru/GetAddressElement", ReplyAction = "*")]
		GetAddressElementResponse GetAddressElement(GetAddressElementRequest request);

		[OperationContract(Action = "http://aisgorod.ru/TestAddress", ReplyAction = "*")]
		void TestAddress();

		[OperationContract(Action = "http://aisgorod.ru/TestSendReq", ReplyAction = "*")]
		void TestSendReq();
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace RequestsClient.RequestService
{
	[DebuggerStepThrough]
	[GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class RequestsServiceSoapClient : ClientBase<RequestsServiceSoap>, RequestsServiceSoap
	{
		public RequestsServiceSoapClient()
		{
			Class38.TqlX7ZmzmDDi2();
			
		}

		public RequestsServiceSoapClient(string endpointConfigurationName)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(endpointConfigurationName);
		}

		public RequestsServiceSoapClient(string endpointConfigurationName, string remoteAddress)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(endpointConfigurationName, remoteAddress);
		}

		public RequestsServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(endpointConfigurationName, remoteAddress);
		}

		public RequestsServiceSoapClient(Binding binding, EndpointAddress remoteAddress)
		{
			Class38.TqlX7ZmzmDDi2();
			base..ctor(binding, remoteAddress);
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		SuccsessResponse RequestsServiceSoap.Succsess(SuccsessRequest request)
		{
			return base.Channel.Succsess(request);
		}

		public Response Succsess(long RequestId, DateTime DateEnd)
		{
			return ((RequestsServiceSoap)this).Succsess(new SuccsessRequest
			{
				Body = new SuccsessRequestBody(),
				Body = 
				{
					RequestId = RequestId,
					DateEnd = DateEnd
				}
			}).Body.SuccsessResult;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		RequestCancelResponse RequestsServiceSoap.RequestCancel(RequestCancelRequest request)
		{
			return base.Channel.RequestCancel(request);
		}

		public Response RequestCancel(long RequestId)
		{
			return ((RequestsServiceSoap)this).RequestCancel(new RequestCancelRequest
			{
				Body = new RequestCancelRequestBody(),
				Body = 
				{
					RequestId = RequestId
				}
			}).Body.RequestCancelResult;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		SendReqResponse RequestsServiceSoap.SendReq(SendReqRequest request)
		{
			return base.Channel.SendReq(request);
		}

		public Response SendReq(Request req)
		{
			return ((RequestsServiceSoap)this).SendReq(new SendReqRequest
			{
				Body = new SendReqRequestBody(),
				Body = 
				{
					req = req
				}
			}).Body.SendReqResult;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		GetDictGroupWorksResponse RequestsServiceSoap.GetDictGroupWorks(GetDictGroupWorksRequest request)
		{
			return base.Channel.GetDictGroupWorks(request);
		}

		public DICTIONARY[] GetDictGroupWorks()
		{
			return ((RequestsServiceSoap)this).GetDictGroupWorks(new GetDictGroupWorksRequest
			{
				Body = new GetDictGroupWorksRequestBody()
			}).Body.GetDictGroupWorksResult;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		GetDictTypeDisableResponse RequestsServiceSoap.GetDictTypeDisable(GetDictTypeDisableRequest request)
		{
			return base.Channel.GetDictTypeDisable(request);
		}

		public DICTIONARY[] GetDictTypeDisable()
		{
			return ((RequestsServiceSoap)this).GetDictTypeDisable(new GetDictTypeDisableRequest
			{
				Body = new GetDictTypeDisableRequestBody()
			}).Body.GetDictTypeDisableResult;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		GetDictTypeRegionResponse RequestsServiceSoap.GetDictTypeRegion(GetDictTypeRegionRequest request)
		{
			return base.Channel.GetDictTypeRegion(request);
		}

		public DICTIONARY[] GetDictTypeRegion()
		{
			return ((RequestsServiceSoap)this).GetDictTypeRegion(new GetDictTypeRegionRequest
			{
				Body = new GetDictTypeRegionRequestBody()
			}).Body.GetDictTypeRegionResult;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		GetDictStatusResponse RequestsServiceSoap.GetDictStatus(GetDictStatusRequest request)
		{
			return base.Channel.GetDictStatus(request);
		}

		public DICTIONARY[] GetDictStatus()
		{
			return ((RequestsServiceSoap)this).GetDictStatus(new GetDictStatusRequest
			{
				Body = new GetDictStatusRequestBody()
			}).Body.GetDictStatusResult;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		GetDictTypeOrganizationResponse RequestsServiceSoap.GetDictTypeOrganization(GetDictTypeOrganizationRequest request)
		{
			return base.Channel.GetDictTypeOrganization(request);
		}

		public DICTIONARY[] GetDictTypeOrganization()
		{
			return ((RequestsServiceSoap)this).GetDictTypeOrganization(new GetDictTypeOrganizationRequest
			{
				Body = new GetDictTypeOrganizationRequestBody()
			}).Body.GetDictTypeOrganizationResult;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		GetAddressElementResponse RequestsServiceSoap.GetAddressElement(GetAddressElementRequest request)
		{
			return base.Channel.GetAddressElement(request);
		}

		public AddressElement[] GetAddressElement(long? parentId)
		{
			return ((RequestsServiceSoap)this).GetAddressElement(new GetAddressElementRequest
			{
				Body = new GetAddressElementRequestBody(),
				Body = 
				{
					parentId = parentId
				}
			}).Body.GetAddressElementResult;
		}

		public void TestAddress()
		{
			base.Channel.TestAddress();
		}

		public void TestSendReq()
		{
			base.Channel.TestSendReq();
		}
	}
}


using BD.PublicPortal.Application.BloodDonationRequests;


namespace BD.PublicPortal.Api.Features.BloodDonationRequests;


public class ListBloodDonationRequestsResponse
{
  public IEnumerable<BloodDonationRequestDTO> BloodDonationRequests { get; set; } = null!;
}



public class ListBloodDonationRequestsEndpoint(IMediator _mediator) : EndpointWithoutRequest<ListBloodDonationRequestsResponse>
{
  
  public override void Configure()
  {
    Get("/BloodDonationRequests");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {

    var res = await  _mediator.Send(new ListBloodDonationRequestsQuery(), cancellationToken);

    if (res.IsSuccess)
    {
      var lwr = new ListBloodDonationRequestsResponse()
      {
        BloodDonationRequests = res.Value
      };
      Response = lwr;
    }
  }
  
}

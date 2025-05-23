﻿using BD.PublicPortal.Application.Identity.GetById;
using BD.PublicPortal.Core.DTOs;


namespace BD.PublicPortal.Api.Features.IdentityManagement.Users.GetById;

public record GetUserByIdEndpointRequest(Guid? UserId);
public class GetUserByIdEndpointResponse
{
  public IEnumerable<ApplicationUserDTO> Users { get; set; } = null!;
}

public class GetUserByIdEndpoint(IMediator _mediator) : Endpoint<GetUserByIdEndpointRequest, GetUserByIdEndpointResponse>
{
  public override void Configure()
  {
    Get("/user/{UserId:guid}");
    AllowAnonymous();
  }
  public override async Task HandleAsync(GetUserByIdEndpointRequest req, CancellationToken cancellationToken)
  {
    var res = await _mediator.Send(new GetUserByIdQuery(req.UserId), cancellationToken);
    if (res.IsSuccess)
    {
      var lwr = new GetUserByIdEndpointResponse()
      {
        Users = res.Value
      };
      Response = lwr;
    }
  }
}

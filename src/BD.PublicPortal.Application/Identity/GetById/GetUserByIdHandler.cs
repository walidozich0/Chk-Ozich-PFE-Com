using BD.PublicPortal.Core.DTOs;
using BD.PublicPortal.Core.Entities;
using BD.PublicPortal.Core.Entities.Specifications;

namespace BD.PublicPortal.Application.Identity.GetById;

public class GetUserByIdHandler(IReadRepository<ApplicationUser> _userRepo) : IQueryHandler<GetUserByIdQuery, Result<IEnumerable<ApplicationUserDTO>>>
{
  public async Task<Result<IEnumerable<ApplicationUserDTO>>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
  {
    var spec = new ApplicationUserSpecification(request.UserId);
    var lst = await _userRepo.ListAsync(spec, cancellationToken);
    var result = lst.ToDtosWithRelated(1);
    return Result<IEnumerable<ApplicationUserDTO>>.Success(result);
  }
}

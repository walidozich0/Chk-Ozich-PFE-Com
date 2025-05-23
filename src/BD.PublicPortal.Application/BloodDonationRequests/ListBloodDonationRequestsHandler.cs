using BD.PublicPortal.Core.DTOs;
using BD.PublicPortal.Core.Entities;
using BD.PublicPortal.Core.Entities.Enums;
using BD.PublicPortal.Core.Entities.Specifications;

namespace BD.PublicPortal.Application.BloodDonationRequests;

public class ListBloodDonationRequestsHandler(IReadRepository<BloodDonationRequest> _bloodDonationRequestsRepo) : IQueryHandler<ListBloodDonationRequestsQuery, Result<IEnumerable<BloodDonationRequestDTO>>>
{
  public async Task<Result<IEnumerable<BloodDonationRequestDTO>>> Handle(ListBloodDonationRequestsQuery request, CancellationToken cancellationToken)
  {
    BloodDonationRequestSpecification spec = new BloodDonationRequestSpecification(filter:request.filter,loggedUserId:request.LoggedUserID,level:request.Level);
    var lst = await _bloodDonationRequestsRepo.ListAsync(spec,cancellationToken);
    var level = (request.Level == null) ? 0 : (int)request.Level;
    return Result<IEnumerable<BloodDonationRequestDTO>>.Success(lst.ToDtosWithRelated(level));
  }
}

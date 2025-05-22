using BD.PublicPortal.Core.Entities;

namespace BD.PublicPortal.Application.BloodDonationRequests;

public class ListBloodDonationRequestsHandler(IReadRepository<BloodDonationRequest> _bloodDonationRequestsRepo) : IQueryHandler<ListBloodDonationRequestsQuery, Result<IEnumerable<BloodDonationRequestDTO>>>
{
  public async Task<Result<IEnumerable<BloodDonationRequestDTO>>> Handle(ListBloodDonationRequestsQuery request, CancellationToken cancellationToken)
  {
    var lst = await _bloodDonationRequestsRepo.ListAsync(cancellationToken);
    return Result<IEnumerable<BloodDonationRequestDTO>>.Success(lst.Select(w => new BloodDonationRequestDTO(
      w.Id,
      w.EvolutionStatus,
      w.DonationType,
      w.BloodGroup,
      w.RequestedQty,
      w.RequestDate,
      w.RequestDueDate,
      w.Priority,
      w.MoreDetails,
      w.ServiceName,
      w.BloodTansfusionCenterId
    )).OrderBy(w => w.Id));
  }
}

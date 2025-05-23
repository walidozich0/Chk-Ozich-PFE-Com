using Ardalis.Specification;

namespace BD.PublicPortal.Core.Entities.Specifications;

#nullable disable

public record BloodDonationRequestSpecificationFilter(
  int? WilayaId = null,
  BloodDonationRequestPriority? ReqPriority = null,
  BloodGroup? BloodGroup = null,
  BloodDonationType? BloodDonationType = null,
  bool? Illigibility = null,
  int? PaginationTake = null,
  int? PaginationSkip = null)
  ;

public class BloodDonationRequestSpecification:Specification<BloodDonationRequest>
{
  public BloodDonationRequestSpecification(BloodDonationRequestSpecificationFilter filter = null,Guid?  loggedUserId = null, int? level = null)
  {

    
    if (level > 0)
      Query.Include(x => x.BloodTansfusionCenter);

    if(filter!=null && filter.WilayaId != null)
      Query.Where(x => x.BloodTansfusionCenter.WilayaId == filter.WilayaId);

    if(filter!=null && filter.ReqPriority != null)
      Query.Where(x => x.Priority == filter.ReqPriority);

    if (filter != null && filter.BloodGroup != null)
      Query.Where(x => x.BloodGroup == filter.BloodGroup);

    if (filter != null && filter.BloodDonationType != null)
      Query.Where(x => x.DonationType == filter.BloodDonationType);

    Query.OrderBy(x => x.BloodTansfusionCenter.WilayaId);

    if (filter != null && filter.PaginationTake != null)
      Query.Take((int)filter.PaginationTake);

    if (filter != null && filter.PaginationSkip != null)
      Query.Skip((int)filter.PaginationSkip);
    
  }

}

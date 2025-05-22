using BD.PublicPortal.Core.Entities.Enums;

namespace BD.PublicPortal.Application.BloodDonationRequests;

public record BloodDonationRequestDTO(
  Guid Id,
  BloodDonationRequestEvolutionStatus? EvolutionStatus,
  BloodDonationType DonationType,
  BloodGroup BloodGroup,
  int RequestedQty,
  DateTime RequestDate,
  DateTime? RequestDueDate,
  BloodDonationRequestPriority Priority,
  string MoreDetails,
  string ServiceName,
  Guid BloodTansfusionCenterId
);

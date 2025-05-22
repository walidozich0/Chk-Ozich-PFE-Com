namespace BD.PublicPortal.Application.BloodDonationRequests;

public record ListBloodDonationRequestsQuery(): IQuery<Result<IEnumerable<BloodDonationRequestDTO>>>;

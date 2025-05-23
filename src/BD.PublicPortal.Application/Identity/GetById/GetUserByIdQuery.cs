using BD.PublicPortal.Core.DTOs;

namespace BD.PublicPortal.Application.Identity.GetById;

public record GetUserByIdQuery(Guid? UserId) :IQuery<Result<IEnumerable<ApplicationUserDTO>>>;

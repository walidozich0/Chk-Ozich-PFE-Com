using BD.PublicPortal.Application.Communes;
using BD.PublicPortal.Core.Entities;
using BD.PublicPortal.Core.Entities.Specifications;
using BD.SharedKernel;


namespace BD.PublicPortal.Application.BTC;

public class ListCommunesHandler(IReadRepository<Commune> _CmnRepo): IQueryHandler<ListCommunesQuery,Result<IEnumerable<CommunesDTO>>>
{
  public async Task<Result<IEnumerable<CommunesDTO>>> Handle(ListCommunesQuery request, CancellationToken cancellationToken)
  {
    var spec = new CommunesSpecifications(request.WilayaId);
    var lst = await _CmnRepo.ListAsync(spec,cancellationToken);
    
    return Result<IEnumerable<CommunesDTO>>.Success(
      lst.Select(btc => new CommunesDTO(btc.Name,btc.WilayaId))
      );
  }
}

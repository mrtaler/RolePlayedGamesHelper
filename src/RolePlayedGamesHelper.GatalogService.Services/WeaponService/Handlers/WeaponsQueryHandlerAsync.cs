using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;
using RolePlayedGamesHelper.Cqrs.Kledex.Queries;
using RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.GatalogService.Services.WeaponService.Queries;
using RolePlayedGamesHelper.Repository.RavenDb;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.GatalogService.Services.WeaponService.Handlers
{
  public class WeaponsQueryHandlerAsync :
      IQueryHandlerAsync<GetWeaponById, Weapon>,
      IQueryHandlerAsync<GetAllWeapons, IEnumerable<Weapon>>
  {
    private readonly IWeaponRepository _weaponRepository;

    private IUnitOfWork<IDocumentSession, RavenDbContextFactory> uow;
    public WeaponsQueryHandlerAsync(IUnitOfWork<IDocumentSession, RavenDbContextFactory> uow)
    {
      this.uow = uow;
    }

    public Task<Weapon> HandleAsync(GetWeaponById query)
    {
      var weap = _weaponRepository.Get(query.WeaponId);
      return Task.FromResult(weap);
    }

    public  Task<IEnumerable<Weapon>> HandleAsync(GetAllWeapons query)
    {
      return Task.FromResult(_weaponRepository.GetAll());
    }
  }
}
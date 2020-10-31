using System.Collections.Generic;
using RolePlayedGamesHelper.Cqrs.Kledex.Queries;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.SharpRepository.FetchStrategies;

namespace RolePlayedGamesHelper.GatalogService.Services.WeaponService.Queries
{
    public class GetWeaponById : IQuery<Weapon>
    {
        public GetWeaponById(int weaponId)
        {
            WeaponId = weaponId;
        }

        public int WeaponId { get; }
    }

    public class GetAllWeapons : IQuery<IEnumerable<Weapon>>
    {
        public IFetchStrategy<Weapon> WeaponIncludes { get; set; }
    }
}

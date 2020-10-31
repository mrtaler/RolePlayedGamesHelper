using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolePlayedGamesHelper.Cqrs.Kledex;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.GatalogService.Services.WeaponService.Queries;
using RolePlayedGamesHelper.Repository.SharpRepository.FetchStrategies;

namespace RolePlayedGamesHelper.GatalogService.Api.Controllers
{
    /// <inheritdoc />
    [Route("weapon")]
    public class WeaponsController : Seedwork.Api.ApiController
  {
        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAll()
        {
            await Dispatcher.PublishAsync(new ServiceDomainEvent("250", "[th")).ConfigureAwait(false);

            var query = new GetAllWeapons
                            {
                                WeaponIncludes = new GenericFetchStrategy<Weapon>()
                            };
            query.WeaponIncludes.Include(x => x.Item);
            query.WeaponIncludes.Include(x => x.WeaponDamages);
            var result = await Dispatcher.GetResultAsync(query).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [Route("one")]
        public async Task<IActionResult> GetOne()
        {
            await Dispatcher.PublishAsync(new ServiceDomainEvent("250", "[th")).ConfigureAwait(false);

            var query = new GetWeaponById(1);
            var result = await Dispatcher.GetResultAsync(query).ConfigureAwait(false);
            return Ok(result);
        }
    }
}

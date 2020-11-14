using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.GatalogService.Services.WeaponService.Queries;
using RolePlayedGamesHelper.Repository.SharpRepository.FetchStrategies;
using RolePlayedGamesHelper.Seedwork.Api;
using RolePlayedGamesHelper.Seedwork.Api.ServiceDomain;

namespace RolePlayedGamesHelper.GatalogService.Api.Controllers
{
    /// <inheritdoc />
    [Route("weapon")]
    public class WeaponsController : CqrsApiController
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

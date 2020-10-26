
namespace RolePlayedGamesHelper.Seedwork.Api.ServiceDomain
{
    /// <summary>
    /// The domain entity.
    /// </summary>
    /// <typeparam name="TEntity">general domain entity
    /// </typeparam>
    public class DomainEntity<TEntity> : TableEntity where TEntity : IDomainEvent
    {
        /// <summary>
        /// Gets or sets the entity object.
        /// </summary>
        public TEntity EntityObject { get; set; }
    }
}
using Microsoft.Extensions.Options;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Configuration
{
    public class SharpRepositoryOptions : IOptions<SharpRepositoryConfiguration>
    {
        public SharpRepositoryOptions(SharpRepositoryConfiguration configuration)
        {
            Value = configuration;
        }

        public SharpRepositoryConfiguration Value { get; protected set; }
    }
}

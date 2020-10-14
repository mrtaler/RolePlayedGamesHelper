namespace RolePlayedGamesHelper.Repository.SharpRepository.Interfaces
{
    public interface IDataContextFactory<out TContext>
        where TContext : class
    {
        TContext GetContext();
    }

}
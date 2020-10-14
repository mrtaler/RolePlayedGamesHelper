namespace RolePlayedGamesHelper.Repository.SharpRepository.Caching
{
    public interface ICachePrefixManager
    {
        int Counter { get; }
        void IncrementCounter();
    }
}

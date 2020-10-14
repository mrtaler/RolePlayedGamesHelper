namespace RolePlayedGamesHelper.Repository.SharpRepository.Ioc
{
    public static class RepositoryDependencyResolver
    {
        static RepositoryDependencyResolver()
        {
            Current = null;
        }

        public static IRepositoryDependencyResolver Current { get; private set; }

        public static void SetDependencyResolver(IRepositoryDependencyResolver resolver)
        {
            Current = resolver;
        }
    }
}
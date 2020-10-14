using System;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Ioc
{
    public interface IRepositoryDependencyResolver
    {
        T Resolve<T>();
        object Resolve(Type type);
    }
}
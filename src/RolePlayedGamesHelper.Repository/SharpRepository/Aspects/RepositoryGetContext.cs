using System;
using System.Linq.Expressions;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Aspects
{
    public class RepositoryGetContext<T, TKey, TResult> : RepositoryActionContext<T, TKey>
        where T : class
    {
        public RepositoryGetContext(IRepository<T, TKey> repository, TKey id, Expression<Func<T, TResult>> selector = null)
            : base(repository)
        {
            Id       = id;
            Selector = selector;
        }

        public TKey Id { get; set; }
        public TResult Result { get; set; }

        public bool HasResult
        {
            get { return Result != null && !Result.Equals(default(TResult)); }
        }

        public Expression<Func<T, TResult>> Selector { get; set; }
    }
}

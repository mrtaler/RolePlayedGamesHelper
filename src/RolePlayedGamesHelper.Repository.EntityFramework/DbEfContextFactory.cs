using System;
using System.Data.Common;
using System.Data.Entity;
using System.Reflection;
using RolePlayedGamesHelper.Repository.EntityFramework.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

namespace RolePlayedGamesHelper.Repository.EntityFramework
{
    public class DbEfContextFactory<TContext> : IDataContextFactory<TContext>
        where TContext : DbContext, IEfDbContext
    {
        private readonly DbConnection options;
        public DbEfContextFactory(DbConnection options)
        {
            this.options = options;
        }

        private TContext context;

        public TContext GetContext()
        {
            context ??= Activator.CreateInstance(typeof(TContext), BindingFlags.Default, null, new object[] { options }, null, null) as TContext;
            context?.Database.CreateIfNotExists();
            return context;
        }
    }
}

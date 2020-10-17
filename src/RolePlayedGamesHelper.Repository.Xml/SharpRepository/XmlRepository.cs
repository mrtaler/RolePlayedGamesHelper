using System.Collections.Generic;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.Xml.SharpRepository
{
    /// <summary>
    /// XML Repository layer
    /// </summary>
    /// <typeparam name="T">The object type that is stored as XML.</typeparam>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public class XmlRepository<T, TKey> : XmlRepositoryBase<T, TKey> 
       where T : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="storagePath">Path to the directory where the XML files are stored.  The XML filename is determined by the TypeName</param>
        /// <param name="cachingStrategy">The caching strategy.  Defaults to <see cref="NoCachingStrategy&lt;T&gt;" />.</param>
        public XmlRepository(List<T> items, string storagePath, ICachingStrategy<T, TKey> cachingStrategy = null) : base(items, storagePath, cachingStrategy)
        {
        }
    }

    /// <summary>
    /// XML Repository layer
    /// </summary>
    /// <typeparam name="T">The object type that is stored as XML.</typeparam>
    public class XmlRepository<T> :
        XmlRepositoryBase<T, int>,
        IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="storagePath">Path to the directory where the XML files are stored.  The XML filename is determined by the TypeName</param>
        /// <param name="cachingStrategy">The caching strategy.  Defaults to <see cref="NoCachingStrategy&lt;T&gt;" />.</param>
        public XmlRepository(List<T> items, string storagePath, ICachingStrategy<T, int> cachingStrategy = null) : base(items, storagePath, cachingStrategy)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using RolePlayedGamesHelper.Repository.SharpRepository.Configuration;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;
using RolePlayedGamesHelper.Repository.Xml.SharpRepository;

namespace RolePlayedGamesHelper.Repository.Xml
{
    public class XmlRepositoryFactory : RepositoryFactoryBase<XmlContextFactory, string>
    {

        /// <inheritdoc />
        public XmlRepositoryFactory(XmlContextFactory dataContextFactory) : base(dataContextFactory)
        {
        }


        /// <inheritdoc />
        public override IRepository<T> GetInstance<T>()
        {
            var (items, storagePath) = getrep<T>();

            return string.IsNullOrEmpty(DataContextFactory.GetContext())
                ? throw new ConfigurationErrorsException(
                    "The directory attribute is required in order to use the XmlRepository via the configuration file.")
                : new XmlRepository<T>(items, storagePath);
        }


        /// <inheritdoc />
        public override IRepository<T, TKey> GetInstance<T, TKey>()
        {
            var (items, storagePath) = getrep<T>();


            return
            string.IsNullOrEmpty(DataContextFactory.GetContext())
                ? throw new ConfigurationErrorsException(
                    "The directory attribute is required in order to use the XmlRepository via the configuration file.")
                : new XmlRepository<T, TKey>(items, storagePath);
        }

        /// <inheritdoc />
        public override ICompoundKeyRepository<T, TKey, TKey2> GetInstance<T, TKey, TKey2>() => throw new System.NotImplementedException();

        /// <inheritdoc />
        public override ICompoundKeyRepository<T, TKey, TKey2, TKey3> GetInstance<T, TKey, TKey2, TKey3>() => throw new System.NotImplementedException();

        private (List<T>, string) getrep<T>()
        {
            var _storagePath = DataContextFactory.GetContext();
            var _items = new List<T>();

            if (!_storagePath.EndsWith(@"\"))
            {
                _storagePath += @"\";
            }
            var entityType = typeof(T);
            var _typeName = entityType.Name;

            _storagePath = String.Format("{0}{1}.xml", _storagePath, _typeName);

            if (!File.Exists(_storagePath)) throw new ConfigurationErrorsException(
                "The directory attribute is required in order to use the XmlRepository via the configuration file.");

            using var stream = new FileStream(_storagePath, FileMode.Open);
            using var reader = new StreamReader(stream);
            var serializer = new XmlSerializer(typeof(List<T>));
            _items = (List<T>)serializer.Deserialize(reader);

            return (_items, _storagePath);
        }
    }
}
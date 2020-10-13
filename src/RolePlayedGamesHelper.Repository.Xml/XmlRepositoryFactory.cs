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
            var (items, storagePath) = Getrep<T>();

            return string.IsNullOrEmpty(DataContextFactory.GetContext())
                ? throw new ConfigurationErrorsException(
                    "The directory attribute is required in order to use the XmlRepository via the configuration file.")
                : new XmlRepository<T>(items, storagePath);
        }


        /// <inheritdoc />
        public override IRepository<T, TKey> GetInstance<T, TKey>()
        {
            var (items, storagePath) = Getrep<T>();


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

        private (List<T>, string) Getrep<T>()
        {
            var storagePath = DataContextFactory.GetContext();
            var items = new List<T>();

            if (!storagePath.EndsWith(@"\"))
            {
                storagePath += @"\";
            }
            var entityType = typeof(T);
            var typeName = entityType.Name;

            storagePath = $"{storagePath}{typeName}.xml";

            if (!File.Exists(storagePath)) throw new ConfigurationErrorsException(
                "The directory attribute is required in order to use the XmlRepository via the configuration file.");

            using var stream = new FileStream(storagePath, FileMode.Open);
            using var reader = new StreamReader(stream);
            var serializer = new XmlSerializer(typeof(List<T>));
            items = (List<T>)serializer.Deserialize(reader);

            return (items, storagePath);
        }
    }
}
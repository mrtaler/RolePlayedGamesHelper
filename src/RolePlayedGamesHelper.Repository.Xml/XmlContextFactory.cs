using System;
using System.Collections;
using System.Collections.Generic;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.Xml
{
    public class XmlContextFactory : IDataContextFactory<string>
    {
        private XmlRepositoryConfiguration _xmlconfiguration;

        public XmlContextFactory(XmlRepositoryConfiguration xmlconfiguration)
        {
            _xmlconfiguration = xmlconfiguration;
        }
        /// <inheritdoc />
        public string GetContext()
        {
            return _xmlconfiguration["directory"];
        }

    }
}
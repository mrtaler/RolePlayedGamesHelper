using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces;

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
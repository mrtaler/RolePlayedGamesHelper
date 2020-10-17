using RolePlayedGamesHelper.Repository.SharpRepository.Configuration;

namespace RolePlayedGamesHelper.Repository.Xml
{
    public class XmlRepositoryConfiguration : RepositoryConfiguration
    {
        public XmlRepositoryConfiguration(string name, string directory)
        {
            Name      = name;
            Directory = directory;
        }

        public string Directory
        {
            set { Attributes["directory"] = value; }
        }
    }
}

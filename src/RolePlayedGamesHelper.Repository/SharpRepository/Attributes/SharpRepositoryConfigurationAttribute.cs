using System;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Attributes
{
     [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SharpRepositoryConfigurationAttribute : System.Attribute
     {
         public SharpRepositoryConfigurationAttribute(string repositoryName)
         {
             RepositoryName = repositoryName;
         }

         public string RepositoryName { get; private set; }
//         public string CachingStrategyName { get; set; }
//         public string CachingProviderName { get; set; }

     }
}

using System;
using RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects.Assert;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.Common
{
    public class CurrentDirectory : RelativeDirectory
    {
        /// <summary>
        ///  Sets the relative directory location based on the environment's current directory.
        ///  Often this is the project's debug location when running locally.
        /// </summary>
        public CurrentDirectory() : base(AppDomain.CurrentDomain.BaseDirectory)
        {
        }
    }
}
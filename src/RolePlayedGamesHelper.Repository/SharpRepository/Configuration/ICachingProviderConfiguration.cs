using System;
using System.Collections.Generic;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;

namespace RolePlayedGamesHelper.Repository.SharpRepository.Configuration
{
    public interface ICachingProviderConfiguration
    {
        string Name { get; set; }
        Type Factory { get; set; }
        IDictionary<string, string> Attributes { get; set; }
        string this[string key] { get; }

        ICachingProvider GetInstance();
    }
}

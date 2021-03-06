﻿using System;
using Moq;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.Common
{
    public class TestHelper : ITestHelper
    {
        public T MakeMock<T>(params Action<Mock<T>>[] mockSetups)
            where T : class
        {
            var mock = new Mock<T>();

            foreach (var mockSetup in mockSetups)
            {
                mockSetup(mock);
            }

            return mock.Object;
        }
    }
}
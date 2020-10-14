using System.Threading;
using RolePlayedGamesHelper.Repository.SharpRepository.Aspects;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects
{
    internal sealed class SpecificAuditAttribute : AuditAttributeMock
    {
        public override void OnGetExecuted<T, TKey, TResult>(RepositoryGetContext<T, TKey, TResult> context)
        {
            Thread.Sleep(50);
            base.OnGetExecuted(context);
        }
    }
}
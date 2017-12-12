using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClassManagementSystem.Scheduling
{
    public interface IScheduledTask
    {
        TimeSpan Interval { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
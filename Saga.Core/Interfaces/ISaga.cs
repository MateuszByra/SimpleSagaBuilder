using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Core.Interfaces
{
    internal interface ISaga
    {
        Guid CorrelationId { get; }
        Task<bool> ExecuteAsync();
    }
}

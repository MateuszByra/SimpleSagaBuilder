using Saga.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Core
{
    public abstract class SagaBase : ISaga
    {
        public Guid CorrelationId { get; private set; }
        private readonly ICollection<Task<bool>> _steps;

        public SagaBase()
        {
            CorrelationId = Guid.NewGuid();
            _steps = new List<Task<bool>>();
        }

        internal void AddStep(Task<bool> func)
        {
            _steps.Add(func);
        }

        public async Task<bool> ExecuteAsync()
        {
            await Task.WhenAll(_steps);
            return _steps.All(t => t.Result);
        }
    }
}

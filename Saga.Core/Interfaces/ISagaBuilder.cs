using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Core.Interfaces
{
    public interface ISagaBuilder<T>
    {
        ISagaBuilder<T> AddStep(Task<bool>step);
        T Build();
    }
}

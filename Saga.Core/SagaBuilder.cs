using System;
using Saga.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Saga.Core
{
    public class SagaBuilder<T> : ISagaBuilder<T> where T: SagaBase, new()
    {
        private T _saga;

        public SagaBuilder()
        {
            _saga = new T();
        }

        public ISagaBuilder<T> AddStep(Task<bool> step)
        {
            _saga.AddStep(step);
            return this;
        }

        public T Build()
        {
            return _saga;
        }
    }
}

using Saga.Core.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Saga.Core.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void BookingSucceeded()
        {
            var vacationSagaBuilder = new VacationSagaBuilder();
            vacationSagaBuilder.AddStep(new BookFlight().Succeeded());
            vacationSagaBuilder.AddStep(new BookHotel().Succeeded());

            var saga = vacationSagaBuilder.Build();

            var result = await saga.ExecuteAsync();
            var correlationId = saga.CorrelationId;

            Assert.True(result);
            Assert.True(correlationId.ToString().Length > 0);
        }
    }

    public class BookHotel
    {
        public async Task<bool> Succeeded()
        {
            await Task.Delay(200);
            return true;
        }

        public async Task<bool> Failed()
        {
            await Task.Delay(200);
            return false;
        }
    }

    public class BookFlight
    {
        public async Task<bool> Succeeded()
        {
            await Task.Delay(200);
            return true;
        }

        public async Task<bool> Failed()
        {
            await Task.Delay(200);
            return false;
        }
    }
    public class VacationSagaBuilder : SagaBuilder<VacationSaga>
    {
        public VacationSagaBuilder()
        {
        }
    }

    public class VacationSaga : SagaBase
    {
        
    }
}

using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;
using Univan.Application.Validation;
using Univan.Domain.Enums;

namespace Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptions
{
    public class GetDriverSubscriptionsQueryHandler : IRequestHandler<GetDriverSubscriptionsQuery, Result<DriverSubscriptionsResult>>
    {
        public async Task<Result<DriverSubscriptionsResult>> Handle(GetDriverSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            DriverSubscriptionsResult driverSubscriptions = null;
            //var driverSubscriptions = _subscriptionRepository.GetDriverSubscription(request.DriverId);

            /*
             *  select for subscription table by driverId. Lista de alunos
             *  Include(Tabela de GO/NOTGO) calcula o freeSeats
             */

            if (driverSubscriptions is null)
            {
                return Result.Fail(ValidationErrors.Subscription.DriverSubscriptionNotFound);
            }

            var result = new DriverSubscriptionsResult()
            {
                FreeSeats = 2,
                Students = new List<DriverStudentsResult>()
                {
                    new DriverStudentsResult()
                    {
                        Name = "Mateus",
                        Situation = StudentSituation.GO,
                        SubscriptionId = 1
                    }
                }
            };

            return Result.Ok(result);
        }
    }
}

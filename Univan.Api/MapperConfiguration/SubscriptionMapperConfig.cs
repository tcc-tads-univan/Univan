using Mapster;
using Univan.Api.Contracts.Subscription;
using Univan.Application.Contracts.Subscription;
using Univan.Application.Services.Subscriber.Command.InviteSubscription;

namespace Univan.Api.MapperConfiguration
{
    public class SubscriptionMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateInviteSubscriptionRequest, InviteSubscriptionCommand>();

            config.NewConfig<DriverStudentSubscriptionResponse, DriverStudentSubscriptionResult>();

            config.NewConfig<StudentPendingSubscriptionsResult, StudentPendingSubscriptionsResponse>();

            config.NewConfig<DriverSubscriptionsResponse, DriverSubscriptionsResult>();

            config.NewConfig<StudentSubscriptionResult, StudentSubscriptionResponse>();
        }
    }
}

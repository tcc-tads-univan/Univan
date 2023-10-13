using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Command.InviteSubscription
{
    public class InviteSubscriptionCommandHandler : IRequestHandler<InviteSubscriptionCommand, Result>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public InviteSubscriptionCommandHandler(IStudentRepository studentRepository, IDriverRepository driverRepository, ISubscriptionRepository subscriptionRepository)
        {
            _studentRepository = studentRepository;
            _driverRepository = driverRepository;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Result> Handle(InviteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetUserById(request.StudentId);
            
            if(student is null)
            {
                return Result.Fail(ValidationErrors.Student.NotFound);
            }

            var driver = await _driverRepository.GetUserById(request.DriverId);

            if(driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.NotFound);
            }

            if(!DriverHasVehicle(driver.VehicleId))
            {
                return Result.Fail(ValidationErrors.Driver.VehicleNotFound);
            }

            if(await HasAvailableSeats(driver.Id, driver.VehicleId.Value) == false)
            {
                return Result.Fail(ValidationErrors.Subscription.StudentsLimitation);
            }

            var subscription = new Subscription()
            {
                DriverId = driver.Id,
                StudentId = student.Id,
                MonthlyFee = request.MonthlyFee,
                ExpirationDay = request.ExpirationDay,
                Status = nameof(SubscriptionStatus.PENDING)
            };

            await _subscriptionRepository.CreateSubscription(subscription);

            return Result.Ok();
        }

        private bool DriverHasVehicle(int? vehicleId)
        {
            return vehicleId.HasValue;
        }
        private async Task<bool> HasAvailableSeats(int driverId, int vehicleId)
        {
            var driverVehicle = await _driverRepository.GetDriverVehicle(driverId, vehicleId);
            var driverSubs = await _driverRepository.GetSubscriptions(driverId);
            return driverVehicle.Seats > driverSubs.Count();
        }
    }
}

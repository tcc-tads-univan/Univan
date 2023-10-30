using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
using Univan.Domain.Events;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Command.InviteSubscription
{
    public class InviteSubscriptionCommandHandler : IRequestHandler<InviteSubscriptionCommand, Result>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMediator _mediator;

        public InviteSubscriptionCommandHandler(IStudentRepository studentRepository, IDriverRepository driverRepository, ISubscriptionRepository subscriptionRepository, IMediator mediator)
        {
            _studentRepository = studentRepository;
            _driverRepository = driverRepository;
            _subscriptionRepository = subscriptionRepository;
            _mediator = mediator;
        }

        public async Task<Result> Handle(InviteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var userValidation = await ValidateStudent(request.StudentId);

            if (userValidation.IsFailed)
            {
                return Result.Fail(userValidation.Errors.FirstOrDefault());
            }

            var driverValidation = await ValidateDriver(request.DriverId);

            if (driverValidation.IsFailed)
            {
                return Result.Fail(driverValidation.Errors.FirstOrDefault());
            }

            var subscription = new Subscription()
            {
                DriverId = request.DriverId,
                StudentId = request.StudentId,
                MonthlyFee = request.MonthlyFee,
                ExpirationDay = request.ExpirationDay,
                Status = nameof(SubscriptionStatus.PENDING)
            };

            await _subscriptionRepository.CreateSubscription(subscription);

            await _mediator.Publish(new InviteSubscriptionMessage(subscription.DriverId, subscription.StudentId, subscription.MonthlyFee, subscription.ExpirationDay));

            return Result.Ok();
        }
        private async Task<Result> ValidateStudent(int studentId)
        {
            var student = await _studentRepository.GetUserById(studentId);

            if (student is null)
            {
                return Result.Fail(ValidationErrors.Student.NotFound);
            }

            if (await StudentHasSubscription(student.Id))
            {
                return Result.Fail(ValidationErrors.Student.AlreadyHasSubscription);
            }

            return Result.Ok();
        }
        private async Task<Result> ValidateDriver(int driverId)
        {
            var driver = await _driverRepository.GetUserById(driverId);

            if (driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.NotFound);
            }

            if (!DriverHasVehicle(driver.VehicleId))
            {
                return Result.Fail(ValidationErrors.Driver.VehicleNotFound);
            }

            if (await HasAvailableSeats(driver.Id, driver.VehicleId.Value) == false)
            {
                return Result.Fail(ValidationErrors.Subscription.StudentsLimitation);
            }

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

        private Task<bool> StudentHasSubscription(int studentId)
        {
            return _studentRepository.HasSubscription(studentId);
        }

    }
}

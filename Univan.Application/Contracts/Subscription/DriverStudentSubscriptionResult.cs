﻿namespace Univan.Application.Contracts.Subscription
{
    public class DriverStudentSubscriptionResult
    {
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string FinalAddress { get; set; }
        public string SubscriptionStatus { get; set; }
        public Payment Payment { get; set; }
    }
}

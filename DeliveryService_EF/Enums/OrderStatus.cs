namespace DeliveryService_EF.Enums
{
    public enum OrderStatus
    {
        Unknown,
        AwaitingPayment,
        Processing,
        AwaitingDelivery,
        BeingDelivered,
        Delivered,
        AwaitingPickup,
        Completed,
        Cancelled,
        Declined,
        Refunded
    }
}

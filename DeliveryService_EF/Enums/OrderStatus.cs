namespace AltexFood_Delivery.DAL.Enums
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

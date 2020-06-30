namespace Atomiv.Template.Core.Common.Orders
{
    public enum OrderItemStatus : byte
    {
        None = 0,
        Pending = 1,
        Allocated = 2,
        Unavailable = 3,
    }
}
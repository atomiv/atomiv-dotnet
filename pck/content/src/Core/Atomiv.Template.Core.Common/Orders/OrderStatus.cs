namespace Atomiv.Template.Core.Common.Orders
{
    public enum OrderStatus : byte
    {
        None = 0,
        Draft = 1,
        Submitted = 2,
        Shipped = 3,
        Cancelled = 4
    }
}
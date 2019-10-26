namespace Optivem.Template.Core.Domain.Orders
{
    public enum OrderDetailStatus : byte
    {
        None = 0,
        Allocated = 1,
        Invoiced = 2,
        Shipped = 3,
        OnOrder = 4,
        NoStock = 5,
    }
}
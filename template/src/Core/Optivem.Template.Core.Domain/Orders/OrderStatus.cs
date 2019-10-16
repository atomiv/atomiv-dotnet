namespace Optivem.Template.Core.Domain.Orders
{
    public enum OrderStatus
    {
        None = 0,
        New = 1,
        Invoiced = 2,
        Shipped = 3,
        Closed = 4,

        // TODO: VC: DELETE
        Submitted = 7,

        Cancelled = 8,
        Archived = 9,
    }
}
namespace Atomiv.Template.Core.Common.Requests
{
    public enum RequestType : byte
    {
        None = 0,

        #region Customers

        CreateCustomer = 1,
        DeleteCustomer = 2,
        EditCustomer = 3,
        
        BrowseCustomers = 4,
        FilterCustomers = 5,
        ViewCustomer = 6,

        #endregion

        #region Orders

        ArchiveOrder = 7,
        CancelOrder = 8,
        CreateOrder = 9,
        EditOrder = 10,
        SubmitOrder = 11,

        BrowseOrders = 12,
        FilterOrders = 13,
        ViewOrder = 14,

        #endregion

        #region Products

        CreateProduct = 15,
        editProduct = 16,
        RelistProduct = 17,
        SyncProducts = 18,
        UnlistProduct = 19,

        BrowseProducts = 20,
        FilterProducts = 21,
        ViewProduct = 22,

        #endregion
    }
}

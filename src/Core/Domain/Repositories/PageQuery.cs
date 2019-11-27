namespace Optivem.Framework.Core.Domain
{
    public struct PageQuery
    {
        public PageQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }

        public int Page { get; }

        public int Size { get; }
    }
}

namespace Optivem.Framework.Core.Domain
{
    public class PageQuery : ValueObject
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

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class ElementObject
    {
        public ElementObject(ElementRoot element)
        {
            Element = element;
        }

        public ElementRoot Element { get; }
    }
}

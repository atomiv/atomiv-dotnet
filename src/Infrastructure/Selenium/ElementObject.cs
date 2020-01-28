namespace Optivem.Atomiv.Infrastructure.Selenium
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
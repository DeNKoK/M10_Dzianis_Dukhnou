using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebElements
{
    public abstract class ElementDecorator : BaseElement
    {
        protected BaseElement webElement;

        protected ElementDecorator(BaseElement webElement, By locator) : base(locator)
        {
            this.webElement = webElement;
        }
    }
}

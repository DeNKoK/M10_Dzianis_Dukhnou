using M8_Dzianis_Dukhnou.WebDriver;

namespace M8_Dzianis_Dukhnou.WebElements
{
    public class JsDecorator : ElementDecorator
    {
        public JsDecorator(BaseElement webElement) : base(webElement, webElement.locator) { }

        public override void Click()
        {
            WaitForIsVisible();
            jsExecutor.ExecuteScript("arguments[0].click();", Browser.GetDriver().FindElement(_locator));
        }
    }
}
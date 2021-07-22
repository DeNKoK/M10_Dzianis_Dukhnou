using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using M8_Dzianis_Dukhnou.WebDriver;

namespace M8_Dzianis_Dukhnou
{
    public class BaseElement : Element
    {
        public By _locator { get; protected set; }
        protected Actions action = new Actions(Browser.GetDriver());
        protected IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Browser.GetDriver();

        public BaseElement(By locator) : base(locator)
        {
            _locator = locator;
        }

        public override void WaitForIsVisible()
        {
            new WebDriverWait
                (
                Browser.GetDriver(),
                TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(_locator)
                );
        }

        public override bool IsElementDisplayed()
        {
            try
            {
                WaitForIsVisible();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string GetText()
        {
            WaitForIsVisible();

            return Browser.GetDriver().FindElement(_locator).Text;
        }

        public override void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Click();
        }

        public override void RightClick(IWebElement letter)
        {
            WaitForIsVisible();
            action.ContextClick(letter).Build().Perform();
        }

        public override ReadOnlyCollection<IWebElement> GetElements()
        {
            WaitForIsVisible();

            return Browser.GetDriver().FindElements(_locator);
        }

        public override void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
        }
    }
}
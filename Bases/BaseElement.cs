using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using M8_Dzianis_Dukhnou.WebDriver;

namespace M8_Dzianis_Dukhnou
{
    public class BaseElement : IWebElement
    {
        protected By _locator;
        protected Actions action = new Actions(Browser.GetDriver());
        protected IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Browser.GetDriver();

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        public void WaitForIsVisible()
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(_locator));
        }

        public bool IsElementDisplayed()
        {
            try
            {
                WaitForIsVisible();

                return Browser.GetDriver().FindElement(_locator).Displayed; //Might be changed just to "true"
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetText()
        {
            WaitForIsVisible();

            return Browser.GetDriver().FindElement(_locator).Text;
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Click();
        }

        public void RightClick(IWebElement letter)
        {
            WaitForIsVisible();
            action.ContextClick(letter).Build().Perform();
        }

        public void JsClick()
        {
            WaitForIsVisible();
            jsExecutor.ExecuteScript("arguments[0].click();", Browser.GetDriver().FindElement(_locator));
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
        
        public ReadOnlyCollection<IWebElement> GetElements()
        {
            WaitForIsVisible();

            return Browser.GetDriver().FindElements(_locator);
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }
    }
}
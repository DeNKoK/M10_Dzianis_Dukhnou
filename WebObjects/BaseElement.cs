using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using M8_Dzianis_Dukhnou.WebDriver;

namespace M8_Dzianis_Dukhnou.WebObjects
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

        public string TagName => throw new System.NotImplementedException();

        public string Text => throw new System.NotImplementedException();

        public bool Enabled => throw new System.NotImplementedException();

        public bool Selected => throw new System.NotImplementedException();

        public Point Location => throw new System.NotImplementedException();

        public Size Size => throw new System.NotImplementedException();

        public bool Displayed => throw new System.NotImplementedException();

        public void WaitForIsVisible()
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(_locator));
        }

        public bool IsElementDisplayed()
        {
            try
            {
                WaitForIsVisible();

                return Browser.GetDriver().FindElement(_locator).Displayed;
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
            throw new System.NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new System.NotImplementedException();
        }
        
        public ReadOnlyCollection<IWebElement> GetElements()
        {
            WaitForIsVisible();

            return Browser.GetDriver().FindElements(_locator);
        }

        public string GetAttribute(string attributeName)
        {
            throw new System.NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new System.NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new System.NotImplementedException();
        }
    }
}
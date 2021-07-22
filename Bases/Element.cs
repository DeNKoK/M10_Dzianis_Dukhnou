using M8_Dzianis_Dukhnou.WebElements;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace M8_Dzianis_Dukhnou
{
    public abstract class Element : IWebElementBase
    {
        public By locator { get; protected set; }

        protected Element(By locator)
        {
            this.locator = locator;
        }

        public abstract void WaitForIsVisible();

        public abstract bool IsElementDisplayed();

        public abstract string GetText();

        public abstract void Click();

        public abstract void RightClick(IWebElement letter);

        public abstract ReadOnlyCollection<IWebElement> GetElements();

        public abstract void SendKeys(string text);
    }
}
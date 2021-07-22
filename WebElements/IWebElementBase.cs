using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace M8_Dzianis_Dukhnou.WebElements
{
    public interface IWebElementBase
    {
        void WaitForIsVisible();
        bool IsElementDisplayed();
        string GetText();
        void Click();
        void RightClick(IWebElement letter);
        ReadOnlyCollection<IWebElement> GetElements();
        void SendKeys(string text);
    }
}
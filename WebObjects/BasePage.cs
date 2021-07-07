using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using M8_Dzianis_Dukhnou.WebDriver;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public abstract class BasePage
    {
        protected By _titleLocator;
        protected string _title;
        public static string _titleForm;

        protected Actions action = new Actions(Browser.GetDriver());
        protected IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Browser.GetDriver();

        protected BasePage(By TitleLocator, string title)
        {
            _titleLocator = TitleLocator;
            _title = _titleForm = title;
            WaitIsOpen();
        }

        public void WaitIsOpen()
        {
            var label = new BaseElement(_titleLocator);
            label.WaitForIsVisible();
        }
    }
}
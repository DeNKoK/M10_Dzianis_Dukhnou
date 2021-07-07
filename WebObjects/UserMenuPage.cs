using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class UserMenuPage : BasePage
    {
        private static readonly By StartPageLocator = By.CssSelector(".user-account_has-subname_yes");

        public UserMenuPage() : base(StartPageLocator, "UserMenu Page") { }

        private readonly BaseElement _exitButton = new BaseElement(By.XPath("//span[text() = 'Выйти из сервисов Яндекса']"));

        public void Logoff()
        {
            _exitButton.Click();
        }
    }
}
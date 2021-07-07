using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class StartPage : BasePage
    {
        private static readonly By StartPageLocator = By.CssSelector(".button2_theme_mail-white");

        public StartPage() : base(StartPageLocator, "Start Page") { }

        private readonly BaseElement _loginButton = new BaseElement(By.CssSelector(".button2_theme_mail-white"));

        public LoginPage ClickLogin()
        {
            _loginButton.Click();

            return new LoginPage();
        }
    }
}
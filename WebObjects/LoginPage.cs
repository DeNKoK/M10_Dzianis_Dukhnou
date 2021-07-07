using OpenQA.Selenium;
using M8_Dzianis_Dukhnou.WebDriver;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class LoginPage : BasePage
    {
        private static readonly By StartPageLocator = By.ClassName("passp-auth-content");

        public LoginPage() : base(StartPageLocator, "Login Page") { }

        private readonly BaseElement _submitButton = new BaseElement(By.XPath("//button[contains(@class, 'Button2') and @type = 'submit']"));
        private readonly BaseElement _loginField = new BaseElement(By.Id("passp-field-login"));
        private readonly BaseElement _pswrdField = new BaseElement(By.Id("passp-field-passwd"));

        public HomePage Login()
        {
            PopulateLogin();
            ClickSubmit();
            PopulatePassword();
            ClickSubmit();

            return new HomePage();
        }

        public void PopulateLogin()
        {
            _loginField.SendKeys(Configuration.UserID);
        }

        public void PopulatePassword()
        {
            _pswrdField.SendKeys(Configuration.Password);
        }

        public void ClickSubmit()
        {
            _submitButton.JsClick();
        }
    }
}
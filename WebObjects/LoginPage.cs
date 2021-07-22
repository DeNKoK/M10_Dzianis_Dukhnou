using OpenQA.Selenium;
using M8_Dzianis_Dukhnou.Entities;
using M8_Dzianis_Dukhnou.WebElements;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class LoginPage : BasePage
    {
        private static readonly By StartPageLocator = By.ClassName("passp-auth-content");

        public LoginPage() : base(StartPageLocator, "Login Page") { }

        private BaseElement _submitButton = new BaseElement(By.XPath("//button[contains(@class, 'Button2') and @type = 'submit']"));
        private readonly BaseElement _loginField = new BaseElement(By.Id("passp-field-login"));
        private readonly BaseElement _pswrdField = new BaseElement(By.Id("passp-field-passwd"));

        public HomePage Login(User user)
        {
            PopulateLogin(user._name);
            ClickSubmit();
            PopulatePassword(user._password);
            ClickSubmit();

            return new HomePage();
        }

        public void PopulateLogin(string userID)
        {
            _loginField.SendKeys(userID);
        }

        public void PopulatePassword(string password)
        {
            _pswrdField.SendKeys(password);
        }

        public void ClickSubmit()
        {
            _submitButton = new JsDecorator(_submitButton);
            _submitButton.Click();
        }
    }
}
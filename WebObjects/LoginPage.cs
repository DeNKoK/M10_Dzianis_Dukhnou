using OpenQA.Selenium;
using M8_Dzianis_Dukhnou.Entities;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class LoginPage : BasePage
    {
        private static readonly By StartPageLocator = By.ClassName("passp-auth-content");

        public LoginPage() : base(StartPageLocator, "Login Page") { }

        private BaseElement SubmitButton => new BaseElement(By.XPath("//button[contains(@class, 'Button2') and @type = 'submit']"));
        private BaseElement LoginField => new BaseElement(By.Id("passp-field-login"));
        private BaseElement PswrdField => new BaseElement(By.Id("passp-field-passwd"));

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
            LoginField.SendKeys(userID);
        }

        public void PopulatePassword(string password)
        {
            PswrdField.SendKeys(password);
        }

        public void ClickSubmit()
        {
            SubmitButton.JsClick();
        }
    }
}
using OpenQA.Selenium;
using M8_Dzianis_Dukhnou.Entities;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class LetterPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//span[text() = 'Отправить']");

        public LetterPage() : base(StartPageLocator, "Letter Page") { }

        private BaseElement ToFieldInput => new BaseElement(By.XPath("//div[@class = 'composeYabbles']"));
        private BaseElement ToFieldOutput => new BaseElement(By.XPath("//div[@class = 'ComposeYabble-Text']"));
        private BaseElement Topic => new BaseElement(By.XPath("//span[text() = 'Тема']"));
        private BaseElement SubjectFieldInput => new BaseElement(By.XPath("//input[contains(@class, 'ComposeSubject-TextField')]"));
        private BaseElement SubjectFieldOutput => new BaseElement(By.CssSelector(".mail-MessageSnippet-Item_subject > span:nth-child(1)"));
        private BaseElement MessageField => new BaseElement(By.XPath("//div[@role = 'textbox']"));
        private BaseElement SendButton => new BaseElement(By.CssSelector(".ComposeControlPanel-SendButton > button"));
        private BaseElement SendResultMessage => new BaseElement(By.XPath("//span[text() = 'Письмо отправлено']"));
        private BaseElement CloseButton => new BaseElement(By.CssSelector("div.composeHeader-Buttons:nth-child(2) > div:nth-child(1) > div:nth-child(3) > button"));
        private BaseElement BackToInbox => new BaseElement(By.XPath("//a[text() = 'Вернуться во \"Входящие\"']"));

        public void PopulateEmail(Letter letter)
        {
            PopulateToField(letter._emailTo);
            PopulateSubjectField(letter._subject);
            PopulateMessageField(letter._message);
        }

        public void CloseLetter()
        {
            CloseButton.Click();
        }

        public void PopulateToField(string emailTo)
        {
            ToFieldInput.Click();
            ToFieldInput.SendKeys(emailTo);
        }

        public void PopulateSubjectField(string subject)
        {
            Topic.Click();
            SubjectFieldInput.Click();
            SubjectFieldInput.SendKeys(subject);
        }

        public void PopulateMessageField(string message)
        {
            MessageField.Click();
            MessageField.SendKeys(message);
        }

        public string GetToField()
        {
            return ToFieldOutput.GetText();
        }

        public string GetSubjectField()
        {
            return SubjectFieldOutput.GetText();
        }

        public string GetMessageField()
        {
            return MessageField.GetText();
        }

        public HomePage ClickSend()
        {
            SendButton.Click();
            SendResultMessage.WaitForIsVisible();
            BackToInbox.Click();

            return new HomePage();
        }
    }
}
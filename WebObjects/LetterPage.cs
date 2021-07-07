using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class LetterPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//span[text() = 'Отправить']");

        public LetterPage() : base(StartPageLocator, "Letter Page") { }

        private readonly BaseElement _toFieldInput = new BaseElement(By.XPath("//div[@class = 'composeYabbles']"));
        private readonly BaseElement _toFieldOutput = new BaseElement(By.XPath("//div[@class = 'ComposeYabble-Text']"));
        private readonly BaseElement _topic = new BaseElement(By.XPath("//span[text() = 'Тема']"));
        private readonly BaseElement _subjectFieldInput = new BaseElement(By.XPath("//input[contains(@class, 'ComposeSubject-TextField')]"));
        private readonly BaseElement _subjectFieldOutput = new BaseElement(By.CssSelector(".mail-MessageSnippet-Item_subject > span:nth-child(1)"));
        private readonly BaseElement _messageField = new BaseElement(By.XPath("//div[@role = 'textbox']"));
        private readonly BaseElement _sendButton = new BaseElement(By.CssSelector(".ComposeControlPanel-SendButton > button"));
        private readonly BaseElement _sendResultMessage = new BaseElement(By.XPath("//span[text() = 'Письмо отправлено']"));
        private readonly BaseElement _closeButton = new BaseElement(By.CssSelector("div.composeHeader-Buttons:nth-child(2) > div:nth-child(1) > div:nth-child(3) > button"));
        private readonly BaseElement _backToInbox = new BaseElement(By.XPath("//a[text() = 'Вернуться во \"Входящие\"']"));

        public void PopulateEmail(string emailTo, string subject, string message)
        {
            PopulateToField(emailTo);
            PopulateSubjectField(subject);
            PopulateMessageField(message);
        }

        public void CloseLetter()
        {
            _closeButton.Click();
        }

        public void PopulateToField(string emailTo)
        {
            _toFieldInput.Click();
            _toFieldInput.SendKeys(emailTo);
        }

        public void PopulateSubjectField(string subject)
        {
            _topic.Click();
            _subjectFieldInput.Click();
            _subjectFieldInput.SendKeys(subject);
        }

        public void PopulateMessageField(string message)
        {
            _messageField.Click();
            _messageField.SendKeys(message);
        }

        public string GetToField()
        {
            return _toFieldOutput.GetText();
        }

        public string GetSubjectField()
        {
            return _subjectFieldOutput.GetText();
        }

        public string GetMessageField()
        {
            return _messageField.GetText();
        }

        public HomePage ClickSend()
        {
            _sendButton.Click();
            _sendResultMessage.WaitForIsVisible();
            _backToInbox.Click();

            return new HomePage();
        }
    }
}
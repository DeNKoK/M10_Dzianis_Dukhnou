using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class SentPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//div[@title = 'Закрепить']");

        public SentPage() : base(StartPageLocator, "Sent Page") { }

        private BaseElement SelectAllCheckBox => new BaseElement(By.XPath("//span[@class = 'checkbox_view']"));
        private BaseElement DeleteButton => new BaseElement(By.XPath("//div[contains(@title, 'Delete')]"));
        private BaseElement Letter => new BaseElement(By.XPath("//span[contains(@class, 'js-message-snippet-left')]"));
        private BaseElement SubjectElement(string subject) => new BaseElement(By.XPath($"//span[@Title = '{subject}']"));

        public bool FindLetterBySubject(string subject)
        {
            return SubjectElement(subject).IsElementDisplayed();
        }

        public LetterPage OpenLetterByOrder(int number)
        {
            Letter.GetElements()[number-1].Click();

            return new LetterPage();
        }

        public void DeleteAll()
        {
            SelectAllCheckBox.Click();
            Delete();
        }

        public void Delete()
        {
            DeleteButton.Click();
        }
    }
}
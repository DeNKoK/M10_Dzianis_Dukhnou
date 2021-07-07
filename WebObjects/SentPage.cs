using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class SentPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//div[@title = 'Закрепить']");

        public SentPage() : base(StartPageLocator, "Sent Page") { }

        private readonly BaseElement _selectAllCheckBox = new BaseElement(By.XPath("//span[@class = 'checkbox_view']"));
        private readonly BaseElement _deleteButton = new BaseElement(By.XPath("//div[contains(@title, 'Delete')]"));
        private readonly BaseElement _letter = new BaseElement(By.XPath("//span[contains(@class, 'js-message-snippet-left')]"));

        public bool FindLetterBySubject(string subject)
        {
            var subjectElement = new BaseElement(By.XPath($"//span[@Title = '{subject}']"));

            return subjectElement.IsElementDisplayed();
        }

        public LetterPage OpenLetterByOrder(int number)
        {
            _letter.GetElements()[number-1].Click();

            return new LetterPage();
        }

        public void DeleteAll()
        {
            _selectAllCheckBox.Click();
            Delete();
        }

        public void Delete()
        {
            _deleteButton.Click();
        }
    }
}
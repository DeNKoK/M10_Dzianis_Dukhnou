using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class DraftPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//div[@title = 'Создать шаблон']");

        public DraftPage() : base(StartPageLocator, "Draft Page") { }

        private BaseElement SelectAllCheckBox => new BaseElement(By.XPath("//span[@class = 'checkbox_view']"));
        private BaseElement DeleteButton => new BaseElement(By.XPath("//div[contains(@title, 'Delete')]"));
        private BaseElement Letter => new BaseElement(By.XPath("//span[contains(@class, 'js-message-snippet-left')]"));
        private BaseElement MoveUpButton => new BaseElement(By.CssSelector(".svgicon-mail--MainToolbar-MoveUpSmall > rect"));
        private BaseElement SubjectElement(string subject) => new BaseElement(By.XPath($"//span[@Title = '{subject}']"));

        public bool FindLetterBySubject(string subject)
        {
            return SubjectElement(subject).IsElementDisplayed();
        }
        
        public bool FindMoveUpButton()
        {
            return MoveUpButton.IsElementDisplayed();
        }

        public LetterPage OpenLetterByOrder(int number)
        {
            Letter.GetElements()[number - 1].Click();

            return new LetterPage();
        }

        public RightClickMenuPage RightClickOnTheletter(int number)
        {
            Letter.RightClick(Letter.GetElements()[number - 1]);

            return new RightClickMenuPage();
        }

        public int CountDraftLetters()
        {
            return Letter.GetElements().Count;
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

        public void Scroll(int pixels)
        {
            jsExecutor.ExecuteScript($"window.scrollBy(0, {pixels})");
        }

        public InboxPage BackToTheInboxFolder()
        {
            action.KeyDown(Keys.Control).SendKeys("i").KeyUp(Keys.Control).Perform();

            return new InboxPage();
        }
    }
}
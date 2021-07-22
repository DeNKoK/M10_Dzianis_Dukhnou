using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class DraftPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//div[@title = 'Создать шаблон']");

        public DraftPage() : base(StartPageLocator, "Draft Page") { }

        #region BaseElements

        private readonly BaseElement _selectAllCheckBox = new BaseElement(By.XPath("//span[@class = 'checkbox_view']"));
        private readonly BaseElement _deleteButton = new BaseElement(By.XPath("//div[contains(@title, 'Delete')]"));
        private readonly BaseElement _letter = new BaseElement(By.XPath("//span[contains(@class, 'js-message-snippet-left')]"));
        private readonly BaseElement _moveUpButton = new BaseElement(By.CssSelector(".svgicon-mail--MainToolbar-MoveUpSmall > rect"));
        private BaseElement SubjectElement(string subject) => new BaseElement(By.XPath($"//span[@Title = '{subject}']"));

        #endregion

        public bool FindLetterBySubject(string subject)
        {
            return SubjectElement(subject).IsElementDisplayed();
        }
        
        public bool FindMoveUpButton()
        {
            return _moveUpButton.IsElementDisplayed();
        }

        public LetterPage OpenLetterByOrder(int number)
        {
            _letter.GetElements()[number - 1].Click();

            return new LetterPage();
        }

        public RightClickMenuPage RightClickOnTheletter(int number)
        {
            _letter.RightClick(_letter.GetElements()[number - 1]);

            return new RightClickMenuPage();
        }

        public int CountDraftLetters()
        {
            return _letter.GetElements().Count;
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
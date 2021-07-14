using OpenQA.Selenium;
using M8_Dzianis_Dukhnou.WebDriver;
using M8_Dzianis_Dukhnou.Entities;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class HomePage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//a[@href = 'https://360.yandex.ru/?from=header-360']");

        public HomePage() : base(StartPageLocator, "Home Page") { }

        private readonly BaseElement _sentItemsButton = new BaseElement(By.XPath("//span[text() = 'Отправленные']"));
        private readonly BaseElement _draftsButton = new BaseElement (By.XPath("//span[text() = 'Черновики']"));
        private readonly BaseElement _inboxButton = new BaseElement (By.XPath("//span[text() = 'Входящие']"));
        private readonly BaseElement _refreshButton = new BaseElement (By.XPath("//span[@data-click-action='mailbox.check']"));
        private readonly BaseElement _writeButton = new BaseElement (By.XPath("//a[contains(@class, 'mail-ComposeButton')]"));
        private readonly BaseElement _userIcon = new BaseElement (By.XPath("//div[contains(@class, 'user-pic user-pic')]"));
        private readonly BaseElement _userName = new BaseElement(By.XPath($"//span[text() ='{Configuration.UserID}']"));

        public bool FindAccountIconByAccountName()
        {
            return _userName.IsElementDisplayed();
        }

        public InboxPage OpenInboxLetters()
        {
            _inboxButton.Click();

            return new InboxPage();
        }

        public SentPage OpenSentLetters()
        {
            _sentItemsButton.Click();

            return new SentPage();
        }

        public DraftPage OpenDraftLetters()
        {
            _draftsButton.Click();

            return new DraftPage();
        }

        public void Refresh()
        {
            _refreshButton.Click();
        }

        public LetterPage CreateNewLetter ()
        {
            _writeButton.Click();

            return new LetterPage();
        }

        public void CreateNumberOfDraftLetters(int number, Letter letter)
        {
            LetterPage letterPage;

            for (int i = 0; i < number; i++)
            {
                letterPage = CreateNewLetter();
                letterPage.PopulateEmail(letter);
                letterPage.CloseLetter();
            }
        }

        public UserMenuPage OpenUserMenu()
        {
            _userIcon.Click();

            return new UserMenuPage();
        }
    }
}
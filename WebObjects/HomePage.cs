using OpenQA.Selenium;
using M8_Dzianis_Dukhnou.WebDriver;
using M8_Dzianis_Dukhnou.Entities;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class HomePage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//a[@href = 'https://360.yandex.ru/?from=header-360']");

        public HomePage() : base(StartPageLocator, "Home Page") { }

        private BaseElement SentItemsButton => new BaseElement(By.XPath("//span[text() = 'Отправленные']"));
        private BaseElement DraftsButton => new BaseElement (By.XPath("//span[text() = 'Черновики']"));
        private BaseElement InboxButton => new BaseElement (By.XPath("//span[text() = 'Входящие']"));
        private BaseElement RefreshButton => new BaseElement (By.XPath("//span[@data-click-action='mailbox.check']"));
        private BaseElement WriteButton => new BaseElement (By.XPath("//a[contains(@class, 'mail-ComposeButton')]"));
        private BaseElement UserIcon => new BaseElement (By.XPath("//div[contains(@class, 'user-pic user-pic')]"));
        private BaseElement UserName => new BaseElement(By.XPath($"//span[text() ='{Configuration.UserID}']"));

        public bool FindAccountIconByAccountName()
        {
            return UserName.IsElementDisplayed();
        }

        public InboxPage OpenInboxLetters()
        {
            InboxButton.Click();

            return new InboxPage();
        }

        public SentPage OpenSentLetters()
        {
            SentItemsButton.Click();

            return new SentPage();
        }

        public DraftPage OpenDraftLetters()
        {
            DraftsButton.Click();

            return new DraftPage();
        }

        public void Refresh()
        {
            RefreshButton.Click();
        }

        public LetterPage CreateNewLetter ()
        {
            WriteButton.Click();

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
            UserIcon.Click();

            return new UserMenuPage();
        }
    }
}
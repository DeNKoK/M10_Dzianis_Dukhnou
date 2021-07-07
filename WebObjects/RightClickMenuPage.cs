using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class RightClickMenuPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//div[@data-id = '8']");

        public RightClickMenuPage() : base(StartPageLocator, "RightClick Page") { }

        private readonly BaseElement _deleteButton = new BaseElement(By.XPath("//div[@data-id = '2']"));
        private readonly BaseElement _putInFolder = new BaseElement(By.XPath("//div[@data-id = '8']"));
        private readonly BaseElement _putInFolderInbox = new BaseElement(By.XPath("//div[@title = 'Входящие']"));

        public void MoveToInboxFolder ()
        {
            _putInFolder.Click();
            _putInFolderInbox.Click();
        }

        public DraftPage Delete()
        {
            _deleteButton.Click();

            return new DraftPage();
        }
    }
}
using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebObjects
{
    public class RightClickMenuPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//div[@data-id = '8']");

        public RightClickMenuPage() : base(StartPageLocator, "RightClick Page") { }

        private BaseElement DeleteButton => new BaseElement(By.XPath("//div[@data-id = '2']"));
        private BaseElement PutInFolder => new BaseElement(By.XPath("//div[@data-id = '8']"));
        private BaseElement PutInFolderInbox => new BaseElement(By.XPath("//div[@title = 'Входящие']"));

        public void MoveToInboxFolder ()
        {
            PutInFolder.Click();
            PutInFolderInbox.Click();
        }

        public DraftPage Delete()
        {
            DeleteButton.Click();

            return new DraftPage();
        }
    }
}
using NUnit.Framework;
using M8_Dzianis_Dukhnou.WebObjects;
using M8_Dzianis_Dukhnou.WebDriver;
using M8_Dzianis_Dukhnou.Methods;

namespace M8_Dzianis_Dukhnou
{
    public abstract class BaseTest
    {
        protected Browser Browser;
        protected Method method;

        protected StartPage _startPage;
        protected LoginPage _loginPage;
        protected HomePage _homePage;
        protected LetterPage _letterPage;
        protected DraftPage _draftPage;
        protected SentPage _sentPage;
        protected InboxPage _inboxPage;
        protected UserMenuPage _userMenuPage;
        protected RightClickMenuPage _rightClickMenuPage;

        [SetUp]
        public void SetUp()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo();
            method = new Method();

            _startPage = new StartPage();
            _loginPage = _startPage.ClickLogin();
            _homePage = _loginPage.Login();
        }

        [TearDown]
        public void TearDown()
        {
            _userMenuPage = _homePage.OpenUserMenu();
            _userMenuPage.Logoff();
            Browser.Quit();
        }
    }
}
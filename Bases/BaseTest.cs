using NUnit.Framework;
using M8_Dzianis_Dukhnou.WebObjects;
using M8_Dzianis_Dukhnou.WebDriver;
using M8_Dzianis_Dukhnou.Utilities;
using M8_Dzianis_Dukhnou.Entities;

namespace M8_Dzianis_Dukhnou
{
    public abstract class BaseTest
    {
        protected Browser Browser;
        protected Method method;
        protected User user;
        protected Letter letter;

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
            user = new User(
                Configuration.UserID,
                Configuration.Password
                );
            method = new Method();

            _startPage = new StartPage();
            _loginPage = _startPage.ClickLogin();
            _homePage = _loginPage.Login(user);
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
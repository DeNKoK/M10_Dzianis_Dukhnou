using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebDriver
{
    public class BrowserFactory
    {

        public static IWebDriver GetDriver(BrowserType type, Computer computer, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        driver = new ChromeBrowser(timeOutSec).driver;
                        break;
                    }
                case BrowserType.RemoteChrome:
                    {
                        driver = new RemoteChromeBrowser(computer, timeOutSec).driver;
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        driver = new FirefoxBrowser(timeOutSec).driver;
                        break;
                    }
                case BrowserType.RemoteFirefox:
                    {
                        driver = new RemoteFirefoxBrowser(timeOutSec).driver;
                        break;
                    }
            }

            return driver;
        }
    }
}
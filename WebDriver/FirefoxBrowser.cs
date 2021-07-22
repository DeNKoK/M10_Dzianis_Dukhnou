using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace M8_Dzianis_Dukhnou.WebDriver
{
    public class FirefoxBrowser : IBrowser
    {
        private IWebDriver _driver = null;
        private readonly int _timeOutSec;

        public IWebDriver driver
        {
            get
            {
                if (_driver == null)
                {
                    var service = FirefoxDriverService.CreateDefaultService();
                    var options = new FirefoxOptions();
                    _driver = new FirefoxDriver
                        (
                        service,
                        options,
                        TimeSpan.FromSeconds(timeOutSec)
                        );
                }

                return _driver;
            }
        }

        public int timeOutSec
        {
            get
            {
                return _timeOutSec;
            }
        }

        public FirefoxBrowser(int timeOut)
        {
            this._timeOutSec = timeOut;
        }
    }
}

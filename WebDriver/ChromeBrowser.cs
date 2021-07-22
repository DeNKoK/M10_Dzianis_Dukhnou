using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace M8_Dzianis_Dukhnou.WebDriver
{
    public class ChromeBrowser : IBrowser
    {
        private IWebDriver _driver = null;
        private readonly int _timeOutSec;

        public IWebDriver driver
        {
            get
            {
                if (_driver == null)
                {
                    var service = ChromeDriverService.CreateDefaultService();
                    var options = new ChromeOptions();
                    _driver = new ChromeDriver
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

        public ChromeBrowser(int timeOut)
        {
            this._timeOutSec = timeOut;
        }
    }
}
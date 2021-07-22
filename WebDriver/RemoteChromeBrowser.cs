using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace M8_Dzianis_Dukhnou.WebDriver
{
    public class RemoteChromeBrowser : IBrowser
    {
        private IWebDriver _driver = null;
        private readonly Computer _computer;
        private readonly int _timeOutSec;

        public IWebDriver driver
        {
            get
            {
                if (_driver == null)
                {
                    var options = new ChromeOptions();
                    options.PlatformName = _computer.OS.name;
                    options.AddArguments
                        (
                        "enable-automation",
                        "--no-sandbox",
                        "--disable-infobars",
                        "--disable-dev-shm-usage",
                        "--disable-browser-side-navigation",
                        "-disable-gpu",
                        "--ignore-certificate-errors"
                        );
                    _driver = new RemoteWebDriver
                        (
                        new Uri(Configuration.RemoteNode),
                        options.ToCapabilities(),
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

        public RemoteChromeBrowser(Computer computer, int timeOut)
        {
            this._computer = computer;
            this._timeOutSec = timeOut;
        }
    }
}

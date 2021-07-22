using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace M8_Dzianis_Dukhnou.WebDriver
{
    public class RemoteFirefoxBrowser : IBrowser
    {
        private IWebDriver _driver = null;
        private readonly int _timeOutSec;

        public IWebDriver driver
        {
            get
            {
                if (_driver == null)
                {
                    var capability = new DesiredCapabilities();
                    capability.SetCapability(CapabilityType.BrowserName, BrowserType.Firefox.ToString().ToLower());
                    capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Any));
                    _driver = new RemoteWebDriver
                        (
                        new Uri(Configuration.RemoteNode),
                        capability,
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

        public RemoteFirefoxBrowser(int timeOut)
        {
            this._timeOutSec = timeOut;
        }
    }
}
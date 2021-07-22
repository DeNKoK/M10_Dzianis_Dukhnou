using OpenQA.Selenium;

namespace M8_Dzianis_Dukhnou.WebDriver
{
    public interface IBrowser
    {
        IWebDriver driver { get; }
        int timeOutSec { get; }
    }
}
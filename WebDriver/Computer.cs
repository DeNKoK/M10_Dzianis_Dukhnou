namespace M8_Dzianis_Dukhnou.WebDriver
{
    public class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.getInstance(osName);
        }
    }
}

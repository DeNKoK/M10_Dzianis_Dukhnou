namespace M8_Dzianis_Dukhnou.WebDriver
{
    public class OS
    {
        private static OS _instance;

        public string name { get; private set; }

        protected OS(string name)
        {
            this.name = name;
        }

        public static OS getInstance(string name)
        {
            if (_instance == null)
                _instance = new OS(name);
            return _instance;
        }
    }
}
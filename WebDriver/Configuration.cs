using System.Configuration;

namespace M8_Dzianis_Dukhnou.WebDriver
{
    public static class Configuration
    {

        public static string GetEnviromentVar(string var) =>
            ConfigurationManager.AppSettings[var];

        public static string OS => GetEnviromentVar("OS");

        public static string Browser => GetEnviromentVar("Browser");

        public static string RemoteNode => GetEnviromentVar("RemoteNode");

        public static string StartUrl => GetEnviromentVar("StartUrl");

        public static string UserID => GetEnviromentVar("User");

        public static string Password => GetEnviromentVar("Password");

        public static string ElementTimeout => GetEnviromentVar("ElementTimeout");

    }
}
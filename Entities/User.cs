namespace M8_Dzianis_Dukhnou.Entities
{
    public class User
    {
        public readonly string _name;
        public readonly string _password;

        public User(string name, string password)
        {
            this._name = name;
            this._password = password;
        }
    }
}
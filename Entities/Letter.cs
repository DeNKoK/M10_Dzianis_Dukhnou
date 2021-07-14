namespace M8_Dzianis_Dukhnou.Entities
{
    public class Letter
    {
        public readonly string _emailTo;
        public readonly string _subject;
        public readonly string _message;

        public Letter(string emailTo, string subject ,string message)
        {
            this._emailTo = emailTo;
            this._subject = subject;
            this._message = message;
        }
    }
}
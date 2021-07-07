using System;
using System.Text;

namespace M8_Dzianis_Dukhnou.Methods
{
    public class Method
    {
        public string GetRandomString(int length)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(length - 1);
            string alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            int position;

            for (int i = 0; i < length; i++)
            {
                position = rnd.Next(0, alphabet.Length - 1);
                sb.Append(alphabet[position]);
            }

            return sb.ToString();
        }
    }
}
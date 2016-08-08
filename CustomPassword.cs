using System;
using System.Collections;

namespace PasswordManagerApplication
{
    public class CustomPassword
    {
        private String _ApplicationName;
        private String _Password;

        private String encrypt(String _Password)
        {
            // use simply algorithm to make the password reverse
            char[] charArray = _Password.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public CustomPassword(String _ApplicationName, String _Password)
        {
            this._ApplicationName = _ApplicationName;
            this._Password = _Password;
        }

        public String ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }

        public String Password
        {
            get { return encrypt(_Password); }
            set { _Password = encrypt(value); }
        }

        public override string ToString()
        {
            return "Application Name: " + _ApplicationName + "\n" +
                   "Password: " + Password;
        }
    }
}
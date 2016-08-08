using System;
using System.Collections;

namespace PasswordManagerApplication
{
    public class PasswordStore
    {
        public static PasswordStore instance = null;

        private CustomPassword[] _Passwords;
        private int _Count;

        public static PasswordStore GetInstance()
        {
            if (instance != null)
                return instance;

            instance = new PasswordStore();
            return instance;
        }

        public PasswordStore()
        {
            _Passwords = new CustomPassword[100];
            _Count = 0;
        }

        public Boolean Add(CustomPassword _NewPassword)
        {
            if (GetCustomPassword(_NewPassword.ApplicationName) != null)
                return false;

            _Passwords[_Count] = _NewPassword;
            _Count++;
            return true;
        }

        public CustomPassword GetCustomPassword(String _ApplicationName)
        {
            for (int i = 0; i < _Count; i++)
            {
                if (_Passwords[i].ApplicationName.ToUpper() == _ApplicationName.ToUpper())
                    return _Passwords[i];
            }
            return null;
        }

        public String[] GetApplications()
        {
            String[] _Applications = new String[_Passwords.Length];
            for (int i = 0; i < _Count; i++)
            {
                _Applications[i] = _Passwords[i].ApplicationName;
            }
            return _Applications;
        }
    }
}
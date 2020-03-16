using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public class PasswordSet : IPasswordSet
    {

        private PasswordIsSet passwordIsSetDel;

        public PasswordIsSet passwordIsSet { get => passwordIsSetDel; set => passwordIsSetDel = value; }

        public void SetPassword(string password)
        {
            PlayerPrefs.SetString("Password",password);
            if(passwordIsSet!=null)
            {
                passwordIsSet();
            }
        }
    }
}

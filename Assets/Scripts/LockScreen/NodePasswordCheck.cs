using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public class NodePasswordCheck : IPasswordCheck
    {
        private PasswordIsCheck passwordIsCheckDel;

        public PasswordIsCheck passwordIsCheck { get => passwordIsCheckDel; set => passwordIsCheckDel = value; }
        public void CheckPassword(string password)
        {
            bool valid = PlayerPrefs.GetString("Password") == password;
            Debug.LogWarning("check complite " + valid.ToString());
            if (passwordIsCheck != null)
            {
                passwordIsCheck(valid);
            }
        }
    }
}

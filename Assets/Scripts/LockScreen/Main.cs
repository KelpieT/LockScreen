using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public class Main : MonoBehaviour
    {
        IPasswordCheck passwordCheck;
        IPasswordInput passwordInput;
        public GameObject passwordInputGO;//Assign in editor
        IPasswordSet passwordSet;
        void Start()
        {
            passwordCheck = new NodePasswordCheck();
            passwordSet = new PasswordSet();
            passwordInput = passwordInputGO.GetComponent<IPasswordInput>();
            if (PlayerPrefs.HasKey("Password"))
            {
                WhenPasswordIsSet();
            }
            else
            {
                SetNewPassword();
            }
        }
        public void SetNewPassword()//Assign in editor on set password button
        {
            passwordInput.sendPasswordInput = passwordSet.SetPassword;
            passwordSet.passwordIsSet = WhenPasswordIsSet;
        }
        public void WhenPasswordIsSet()
        {
            passwordInput.sendPasswordInput = passwordCheck.CheckPassword;
        }

    }
}

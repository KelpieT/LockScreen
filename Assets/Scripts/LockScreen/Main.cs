using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{

    public class Main : MonoBehaviour
    {
        public delegate void PasswordValid(bool valid);
        public static event PasswordValid passwordValid;

        IPasswordCheck passwordCheck;
        IPasswordInput passwordInput;
        public GameObject passwordInputGO;//Assign in editor
        IPasswordSet passwordSet;
        void Start()
        {
            passwordCheck = new NodePasswordCheckLua();
            passwordSet = new PasswordSet();
            passwordInput = passwordInputGO.GetComponent<IPasswordInput>();
            passwordCheck.passwordIsCheck = PasswordValidation;
            if (PlayerPrefs.HasKey("Password"))
            {
                WhenPasswordIsSet();
            }
            else
            {
                SetNewPassword();
            }
        }
        void PasswordValidation(bool valid)
        {
            if (passwordValid != null)
            {
                passwordValid(valid);
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

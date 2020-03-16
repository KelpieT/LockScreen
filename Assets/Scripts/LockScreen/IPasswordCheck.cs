using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public delegate void PasswordIsCheck(bool valid);
    public interface IPasswordCheck
    {
        PasswordIsCheck passwordIsCheck { get; set; }

        void CheckPassword(string password);
    }
}

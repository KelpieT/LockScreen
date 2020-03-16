using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public delegate void PasswordIsSet();
    public interface IPasswordSet
    {
        PasswordIsSet passwordIsSet { get; set; }

        void SetPassword(string password);
    }
}
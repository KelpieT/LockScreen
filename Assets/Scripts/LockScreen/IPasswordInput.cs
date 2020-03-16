using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public delegate void SendPasswordInput(string passwordInput);
    public interface IPasswordInput
    {
        string PasswordInput { get; set; }
        SendPasswordInput sendPasswordInput { get; set; }
    }
}

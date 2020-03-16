using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public interface IPasswordCheck
    {
        void CheckPassword(string password);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public class NodePasswordCheck : IPasswordCheck
    {
        public void CheckPassword(string password)
        {
            Debug.LogWarning("check complite " + (PlayerPrefs.GetString("Password")==password).ToString());
        }
    }
}

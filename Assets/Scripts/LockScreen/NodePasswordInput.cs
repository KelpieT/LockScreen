using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{
    public class NodePasswordInput : MonoBehaviour, IPasswordInput
    {
        private string passwordInput;
        public string PasswordInput { get => passwordInput; set => passwordInput = value; }
        private SendPasswordInput sendPasswordInputDel;
        public SendPasswordInput sendPasswordInput { get => sendPasswordInputDel; set => sendPasswordInputDel = value; }


        private void OnEnable()
        {
            NodeLockScr.enterNode += AddNodeToPassword;
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PasswordInput = "";
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (sendPasswordInput != null)
                {
                    sendPasswordInput(PasswordInput);
                }
            }
        }
        void AddNodeToPassword(int number)
        {
            PasswordInput += "|" + number.ToString();
        }
        private void OnDisable()
        {
            NodeLockScr.enterNode -= AddNodeToPassword;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LockScreen
{  
    public class NodeLockScr : MonoBehaviour
    {
        
        public delegate void EnterNode(int Number);
        public static event EnterNode enterNode;
        public int Number;
        public void Connecet()//Assign in editor in Event triger
        {
            if(enterNode!=null)
            {
                enterNode(Number);
            }
        }
    }
}

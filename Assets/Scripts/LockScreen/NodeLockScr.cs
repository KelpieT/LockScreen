using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace LockScreen
{
    public class NodeLockScr : MonoBehaviour
    {

        public delegate void EnterNode(int Number);
        public static event EnterNode enterNode;
        public int Number;
        public Image image;
        bool isSelected = false;


        private void OnEnable()
        {
            Main.passwordValid += SetColorValid;
        }
        private void Update()
        {

            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && !isSelected)
            {
                if (IsObjectTaped(gameObject))
                {
                    Connecet();
                }
            }


            if (Input.GetMouseButtonDown(0))
            {
                image.color = Color.white;
            }
        }
        private void LateUpdate()
        {
            if (Input.GetMouseButtonUp(0))
            {
                isSelected = false;
            }
        }
        public void Connecet()//Assign in editor in Event triger
        {


            if (enterNode != null)
            {
                enterNode(Number);

            }
            Debug.Log("Node is Selected");
            isSelected = true;
        }


        private void SetColorValid(bool valid)
        {
            if (isSelected)
            {
                if (valid)
                {
                    image.color = Color.green;
                }
                else
                {
                    image.color = Color.red;
                }
                isSelected = false;

            }

        }
        List<RaycastResult> ListRayOverUI()
        {
            PointerEventData eventCurPos = new PointerEventData(EventSystem.current);
            eventCurPos.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventCurPos, results);
            return results;
        }
        protected bool IsObjectTaped(GameObject g)
        {
            bool b = false;
            foreach (RaycastResult rr in ListRayOverUI())
            {
                if (CheckParent(rr.gameObject, gameObject))
                {
                    b = true;
                    break;
                }
                else
                {
                    break;
                }

            }
            return b;
        }
        bool CheckParent(GameObject gg, GameObject parent)
        {
            if (gg.name == parent.name)
            {
                return true;
            }
            else
            {
                if (gg.transform.parent != null)
                {
                    return CheckParent(gg.transform.parent.gameObject, parent);
                }
                else
                {
                    return false;
                }

            }
        }
        private void OnDisable()
        {
            Main.passwordValid -= SetColorValid;
        }

    }
}

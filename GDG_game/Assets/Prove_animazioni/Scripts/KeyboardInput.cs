using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.MoveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveRight = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.MoveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveLeft = false;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                VirtualInputManager.Instance.Jump = true;
            }
            else
            {
                VirtualInputManager.Instance.Jump = false;
            }

            if (Input.GetKey(KeyCode.E))
            {
                VirtualInputManager.Instance.Pushing = true;
            }
            else
            {
                VirtualInputManager.Instance.Pushing = false;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                VirtualInputManager.Instance.Picking = true;
            }
            else
            {
                VirtualInputManager.Instance.Picking = false;
            }
        }
    }
}


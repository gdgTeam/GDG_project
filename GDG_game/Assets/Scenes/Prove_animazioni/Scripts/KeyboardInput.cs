﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class KeyboardInput : MonoBehaviour
    {
        private bool protectShield = true;
        private bool protectPlant = false;

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
            if (Input.GetKey(KeyCode.W))
            {
                VirtualInputManager.Instance.MoveUp = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveUp = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                VirtualInputManager.Instance.MoveDown = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveDown = false;
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

            if (Input.GetKey(KeyCode.Q) && !protectPlant)
            {
                protectPlant = true;
                VirtualInputManager.Instance.Picking = true;
            }
            else
            {
                VirtualInputManager.Instance.Picking = false;
            }

            if(Input.GetKey(KeyCode.Q) && !VirtualInputManager.Instance.Picking && protectPlant)
            {
                protectPlant = false;
                VirtualInputManager.Instance.PickingDown = true;
            }
            else
            {
                VirtualInputManager.Instance.PickingDown = false;
            }

            if (Input.GetMouseButtonDown(2) && protectShield)
            {
                protectShield = false;
                VirtualInputManager.Instance.Shielding = true;
                StartCoroutine("Shield");
            }
        }

        IEnumerator Shield()
        {
            yield return new WaitForSeconds(5f);
            VirtualInputManager.Instance.Shielding = false;
            yield return new WaitForSeconds(2f);
            protectShield = true;
        }
    }
}


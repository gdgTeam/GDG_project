﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Idle")]
    public class Idle : StateData
    {

        public float BlockDistance;
        public float PickDistance;
        public GameObject hand;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            animator.SetBool(TransitionParameter.Jump.ToString(), false); //per evitare di saltare due volte se premo spazio mentre sono nello stato di landing
            control.RIGID_BODY.velocity = Vector3.zero;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (control.MoveRight)
            {
                
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (control.MoveLeft)
            {
                
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (control.Pushing && CheckFrontPush(control, animator))
            {
                animator.SetBool(TransitionParameter.Push.ToString(), true);
            }

            if (control.Picking && CheckFrontPick(control, animator))
            {
                animator.SetBool(TransitionParameter.PickUp.ToString(), true);
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool CheckFrontPush(CharacterControl control, Animator animator)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance) && hit.collider.gameObject.tag == "Pushable")
                {
                    hit.collider.gameObject.transform.SetParent(animator.gameObject.transform);
                    return true;
                }
            }

            return false;
        }

        bool CheckFrontPick(CharacterControl control, Animator animator)
        {
            foreach (GameObject o in control.FrontSpheres)
            {
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, PickDistance) && hit.collider.gameObject.tag == "Pickable")
                {
                    if(hit.collider.gameObject == GameObject.Find("piantina_prova"))
                    {
                        control.PickPlant = true;
                    }
                    else
                    {
                        control.PickPlant = false;
                    }
                    //hit.collider.gameObject.transform.SetParent(GameObject.Find("RightHand").transform);
                    return true;
                }
            }

            return false;
        }
    }
}
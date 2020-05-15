﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public AnimationCurve SpeedGraph;
        public float Speed;
        public float BlockDistance;
        private bool Self;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (control.MoveRight && control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!control.MoveRight && !control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            //controllo che non ci sia niente davanti il character, se rilevo qualcosa non mi muovo più 
            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                control.SkinnedMeshAnimator.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                if (!CheckFront(control))
                {
                    control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
            }

            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                control.SkinnedMeshAnimator.transform.rotation= Quaternion.Euler(0f, 180f, 0f);
                if (!CheckFront(control))
                {
                    control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

       bool CheckFront(CharacterControl control)
        {
           
            foreach (GameObject o in control.FrontSpheres)
            {
                Self = false;
                Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, 1f))
                {
                    Debug.Log(" ho rilevato");

                    if (hit.collider.gameObject.tag == "Pickable")
                    {
                        BlockDistance = 0.2f;
                    }
                    else
                    {
                        BlockDistance = 0.5f;
                    }

                }
                else
                {
                    Debug.Log(" non rileva niente davanti");
                    BlockDistance = 0.5f;
                }
                if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
                {
                    
                    if (!Self && !Ledge.IsLedge(hit.collider.gameObject))
                    {
                        Debug.Log("Blocca la distanza");
                        return true;
                    }

                    // foreach (Collider c in control.RagdollParts)
                    // {
                    /*if (c.gameObject == hit.collider.gameObject)
                    {
                        Self = true;
                        break;
                    }*/
                }
                   
                    

               //}
            }

            return false;
        }
    }
}
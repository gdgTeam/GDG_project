using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/PickUp")]
    public class PickUp : StateData
    {
        public GameObject piantina;
        CharacterControl control;
        //public GameObject piantinaSpalla;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            piantina = GameObject.Find("piantina_prova");
            if(control.PickPlant == true)
            {
                piantina.transform.SetParent(GameObject.Find("RightHand").transform);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.PickUp.ToString(), false); //per evitare di saltare due volte se premo spazio mentre sono nello stato di landing
            MeshRenderer piantinaManoMesh;
            MeshCollider piantinaManoCollider;
            piantinaManoMesh = piantina.transform.GetComponent<MeshRenderer>();
            piantinaManoMesh.enabled = false;
            piantinaManoCollider = piantina.transform.GetComponent<MeshCollider>();
            piantinaManoCollider.enabled = false;
            control.plant = true;
            /*MeshRenderer piantaSpallaMesh;
            piantaSpallaMesh = piantinaSpalla.transform.GetComponent<MeshRenderer>();
            piantaSpallaMesh.enabled = true;*/
        }
    }
}

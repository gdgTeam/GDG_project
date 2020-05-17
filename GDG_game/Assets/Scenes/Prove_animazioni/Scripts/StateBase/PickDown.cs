using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/PickDown")]
    public class PickDown : StateData
    {
        //public GameObject piantinaSpalla;
        public GameObject piantinaMano;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            piantinaMano = GameObject.Find("piantina_prova");
            /*MeshRenderer piantaSpallaMesh;
            piantaSpallaMesh = piantinaSpalla.transform.GetComponent<MeshRenderer>();
            piantaSpallaMesh.enabled = false;*/
            MeshRenderer piantinaManoMesh;
            MeshCollider piantinaManoCollider;
            piantinaManoMesh = piantinaMano.transform.GetComponent<MeshRenderer>();
            piantinaManoMesh.enabled = true;
            piantinaManoCollider = piantinaMano.transform.GetComponent<MeshCollider>();
            piantinaManoCollider.enabled = false;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            piantinaMano.transform.parent = null;
            control.plant = false;
            /*MeshRenderer piantaSpallaMesh;
            piantaSpallaMesh = piantinaSpalla.transform.GetComponent<MeshRenderer>();
            piantaSpallaMesh.enabled = true;*/
        }
    }
}
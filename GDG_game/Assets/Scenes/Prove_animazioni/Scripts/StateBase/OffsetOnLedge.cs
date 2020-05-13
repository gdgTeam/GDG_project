using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/OffSetOnLedge")]
    public class OffsetOnLedge : StateData
    {
        public Vector3 offsetTestaPiedi;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            CharacterControl control = characterState.GetCharacterControl(animator);
            control.GetComponentInParent<Rigidbody>().transform.localPosition = control.ledgeChecker.grabbedLedge.GetComponent<Rigidbody>().transform.position-offsetTestaPiedi;

        }
        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
           
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

       
    }
}

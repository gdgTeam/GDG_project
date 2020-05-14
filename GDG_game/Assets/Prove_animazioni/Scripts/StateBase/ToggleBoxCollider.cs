﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    [CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/ToggleBoxCollider")]
    public class ToggleBoxCollider : StateData
    {
        public bool OnStart;
        public bool OnEnd;
        public bool On;


        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (OnStart)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                ToggleBoxCol(control);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
             if (OnEnd)
             {
                 CharacterControl control = characterState.GetCharacterControl(animator);
                 ToggleBoxCol(control);
             }

        }

        private void ToggleBoxCol(CharacterControl control)
        {
            
            control.GetComponent<BoxCollider>().enabled = On;
        }


    }
}

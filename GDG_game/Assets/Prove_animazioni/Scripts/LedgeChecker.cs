using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    
    public class LedgeChecker: MonoBehaviour
    {
        Ledge ledge = null;
        private void OnTriggerEnter(Collider other)
        {
            ledge = other.gameObject.GetComponent<Ledge>();

        }
        private void OnTriggerExit(Collider other)
        {
            
        }
    }

}

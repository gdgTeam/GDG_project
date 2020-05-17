using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{


    public class TriggerAnimazioneGradini : MonoBehaviour
    {
        public GameObject gradino1;
        public GameObject gradino2;
        public GameObject gradino3;
        public GameObject gradino4;
        public GameObject gradiniritardo1;
        public GameObject gradiniritardo2;
        public GameObject gradiniritardo3;
        public GameObject ColliderScala;
        public GameObject Corrimano;



        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.tag == "Player")
            {
                
                /* Rigidbody Rbgradino1 = gradino1.GetComponent<Rigidbody>();
                 Rigidbody Rbgradino2 = gradino2.GetComponent<Rigidbody>();
                 Rigidbody Rbgradino3 = gradino3.GetComponent<Rigidbody>();
                 Destroy(Rbgradino1);
                 Destroy(Rbgradino2);
                 Destroy(Rbgradino3);*/
               
                StartCoroutine(AltriGradini());

            }
        }

        private void OnTriggerExit(Collider other)
        {
           
        }
        private IEnumerator AltriGradini()
        {
            gradino1.AddComponent<Rigidbody>();
            gradino1.GetComponent<Rigidbody>().mass = 3f;
            gradino2.AddComponent<Rigidbody>();
            gradino2.GetComponent<Rigidbody>().mass = 3f;
            gradino3.AddComponent<Rigidbody>();
            gradino3.GetComponent<Rigidbody>().mass = 3f;
            gradino4.AddComponent<Rigidbody>();
            gradino4.GetComponent<Rigidbody>().mass = 3f;
            yield return new WaitForSeconds(2f);
            ColliderScala.GetComponent<Collider>().enabled = false;
            gradiniritardo1.AddComponent<Rigidbody>();
            gradiniritardo1.GetComponent<Rigidbody>().mass = 3f;
            gradiniritardo2.AddComponent<Rigidbody>();
            gradiniritardo2.GetComponent<Rigidbody>().mass = 3f;
            gradiniritardo3.AddComponent<Rigidbody>();
            gradiniritardo3.GetComponent<Rigidbody>().mass = 3f;
            //yield return new WaitForSeconds(1f);
           // Corrimano.AddComponent<Rigidbody>();
            //Corrimano.AddComponent<MeshCollider>();
           // Corrimano.GetComponent<Rigidbody>().mass = 10f;

        }


    }

}
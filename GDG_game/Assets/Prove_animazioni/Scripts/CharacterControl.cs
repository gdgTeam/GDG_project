﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
        Grounded,
        Push,
        TransitionIndex,
        PickUp,
        Movedown,
        WalkUpStairs,

    }

    public class CharacterControl : MonoBehaviour
    {
        public Animator SkinnedMeshAnimator;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;
        public bool Pushing;
        public bool Picking;
        public bool PickPlant;
        public bool Shielding;
        private bool protectShield;
        public GameObject ColliderEdgePrefab;
        public List<GameObject> BottomSpheres = new List<GameObject>();
        public List<GameObject> FrontSpheres = new List<GameObject>();
        public bool MoveUp;
        public bool MoveDown;
        public LedgeChecker ledgeChecker;
        public List<Collider> RagdollParts = new List<Collider>();
        public float GravityMultiplier;
        public float PullMultiplier;
        public bool grabCharact;
        public bool WalkUpStair;
        private Rigidbody rigid;
        public StairChecker stairChecker;
        public GameObject Corazza;

        public Rigidbody RIGID_BODY
        {
            get
            {
                if (rigid == null)
                {
                    rigid = GetComponent<Rigidbody>();
                }
                return rigid;
            }
        }
        public Rigidbody RIGID_BODY1
        {
            get
            {
                if (rigid == null)
                {
                    rigid = GetComponent<Rigidbody>();
                }
                return rigid;
            }
        }
        private void Update()
        {
            if (ledgeChecker.IsGrabbingLedge == true)
            {
                grabCharact = true;

            }
            if (ledgeChecker.IsGrabbingLedge == false)
            {
                grabCharact = false;
               
            }
            if (MoveDown == true)
            {
             
             SkinnedMeshAnimator.SetBool(TransitionParameter.Movedown.ToString(), true);
            this.RIGID_BODY1.useGravity = true;
            this.GetComponent<BoxCollider>().enabled = true;

            }
            else if(MoveDown==false)
            {
                SkinnedMeshAnimator.SetBool(TransitionParameter.Movedown.ToString(), false);
            }
            if (stairChecker.StairVal == true)
            {
                Debug.Log("true");
                WalkUpStair = true;

            }
            if (stairChecker.StairVal == false)
            {
                Debug.Log("false");

                WalkUpStair = false;

            }

            if (Shielding && protectShield)
            {
                protectShield = false;
                MeshRenderer meshCorazza = Corazza.transform.GetComponent<MeshRenderer>();
                meshCorazza.enabled = true;
            }
            if (!Shielding && !protectShield)
            {
                protectShield = true;
                MeshRenderer meshCorazza = Corazza.transform.GetComponent<MeshRenderer>();
                meshCorazza.enabled = false;
            }
        }

        private void Awake()
        {
            //SetRagdollParts();
            SetCollidersSpheres();   
        
        }

        private void SetRagdollParts()
         {
             Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
             foreach (Collider c in colliders)
             {
                 if(c.gameObject != this.gameObject)
                 {
                     c.isTrigger = true;
                     RagdollParts.Add(c);
                 }

             }
         }



        private void OnTriggerEnter(Collider col)
         {

             {
                 return;
             }
             if (col.gameObject.tag== "Pericolo")
             {
                 TurnOnRagdoll();
             }
        }
         public void TurnOnRagdoll()
         {
             RIGID_BODY1.useGravity = false;
             RIGID_BODY1.velocity = Vector3.zero;
             this.gameObject.GetComponent<BoxCollider>().enabled = false;
             SkinnedMeshAnimator.enabled = false;
             SkinnedMeshAnimator.avatar = null;
             foreach( Collider c in RagdollParts)
             {
                 c.isTrigger = false;
                 c.attachedRigidbody.velocity = Vector3.zero;
             }
         }


        public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int interations, List<GameObject> spheresList)
        {
            for (int i = 0; i < interations; i++)
            {
                Vector3 pos = start.transform.position + (dir * sec * (i + 1));

                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = this.transform;
                spheresList.Add(newObj);
            }
        }
        private void SetCollidersSpheres()
        {
            BoxCollider box = GetComponent<BoxCollider>();

            float bottom = box.bounds.center.y - box.bounds.extents.y;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float front = box.bounds.center.z + box.bounds.extents.z;
            float back = box.bounds.center.z - box.bounds.extents.z;

            GameObject bottomFront = CreateEdgeSphere(new Vector3(0f, bottom, front));
            GameObject bottomBack = CreateEdgeSphere(new Vector3(0f, bottom, back));
            GameObject topFront = CreateEdgeSphere(new Vector3(0f, top, front));

            bottomFront.transform.parent = this.transform;
            bottomBack.transform.parent = this.transform;
            topFront.transform.parent = this.transform;

            BottomSpheres.Add(bottomFront);
            BottomSpheres.Add(bottomBack);

            FrontSpheres.Add(bottomFront);
            FrontSpheres.Add(topFront);

            float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
            CreateMiddleSpheres(bottomFront, -this.transform.forward, horSec, 4, BottomSpheres);

            float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
            CreateMiddleSpheres(bottomFront, this.transform.up, verSec, 9, FrontSpheres);

        }
        private void FixedUpdate()
        {
            if(RIGID_BODY.velocity.y<0f)
            {
                RIGID_BODY.velocity -= Vector3.up * GravityMultiplier;
            }

           
        }

        public GameObject CreateEdgeSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
            return obj;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{

    public Transform targetTransform;
    public LayerMask mouseAimMask;

    private Rigidbody rg;
    private Camera mainCamera;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, mouseAimMask))
        {
            targetTransform.position = hit.point;
        }
    }

    private void FixedUpdate()
    {
        rg.MoveRotation(Quaternion.Euler(new Vector3(0, 90 - (90 * Mathf.Sign(targetTransform.position.z - transform.position.z)), 0)));
    }



    /*void LateUpdate()
    {
        chest.LookAt(new Vector3(1, Input.mousePosition.y, Input.mousePosition.x));
        chest.rotation = chest.rotation * Quaternion.Euler(Offset);
    }*/
}

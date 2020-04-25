using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    Animator anim;
    private float s;
    private bool isJumping = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (move != 0)
        {
            if (s < 1)
                s += 0.025f;
        }
        else
        {
            if (s > 0) s -= 0.04f;
            else s = 0;
        }
        UpdateAnimations();
        //transform.Translate(transform.forward * s * Time.deltaTime, Space.World);

    }

    private void UpdateAnimations()
    {
        anim.SetFloat("Speed", s);

        if (Input.GetKeyDown(KeyCode.W) && isJumping == false)
        {
            isJumping = true;
            anim.SetTrigger("Jump");
            Debug.Log("Jump");
        }
    }
}

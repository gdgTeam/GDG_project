using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    Animator anim;
    float s;

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
            s += 0.01f;
        }
        else
        {
            if (s > 0) s -= 0.05f;
            else s = 0;
        }
        anim.SetFloat("Speed", s);

    }
}

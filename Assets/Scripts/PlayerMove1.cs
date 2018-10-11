using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour {

    public CharapterController controller;
    public Animator anim;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
   

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) { jump = true;}
        crouch = Input.GetButtonDown("Crouch") ? true : false;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (controller.m_Grounded) { anim.SetBool("Isjumping", false); } else { anim.SetBool("Isjumping", true); }

    }

   
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}

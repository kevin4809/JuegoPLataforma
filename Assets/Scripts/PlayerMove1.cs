using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour {

    public CharapterController controller;
    public Animator anim;
    public float runSpeed = 40f;
    float prueba;
    public float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Rigidbody2D body;
    public  float countDashh = 0.8f;


    float countTime;
    bool isSlider;
    bool isSlider2;
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) { jump = true;}
        crouch = Input.GetButtonDown("Crouch") ? true : false;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        anim.SetFloat("Isdash", Mathf.Abs(prueba));


        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        bool JumpingWall = stateinfo.IsName("Jump_Wall");

        if (controller.m_Grounded && !JumpingWall) { anim.SetBool("Isjumping", false); } else { anim.SetBool("Isjumping", true); }

        if (Input.GetKeyDown(KeyCode.LeftShift) && countDashh >= 0 && controller.m_Grounded)
        {
             isSlider = true;
               
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift)  && countDashh >= 0 && controller.m_Grounded)
        {
            isSlider2 = true;     
        }
        else { prueba = 0; }

        if (countDashh < 0) { StartCoroutine(countDash()); isSlider = false; isSlider2 = false; }

        Dash();
    }

    IEnumerator countDash()
    {
        yield return new WaitForSeconds(0.8f);
        countDashh = 0.8f;
        isSlider = false;
        isSlider2 = false;
        runSpeed = 40f;
    }
   
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void Dash()
    {
        if (isSlider)
        {
            prueba = 1;
            runSpeed = 80f;
     
            countDashh -= Time.deltaTime;
        }

        if (isSlider2)
        {
            prueba = 1;
            runSpeed = 80f;
            countDashh -= Time.deltaTime;
        }
    }
}

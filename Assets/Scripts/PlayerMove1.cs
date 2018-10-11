using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour {

    public CharapterController controller;
    public Animator anim;
    public float runSpeed = 40f;
    float prueba;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Rigidbody2D body;
    public  float countDashh = 1;


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

        if (controller.m_Grounded) { anim.SetBool("Isjumping", false); } else { anim.SetBool("Isjumping", true); }

        if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalMove > 0 && countDashh >= 0)
        {
                isSlider = true;
               
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalMove < 0 && countDashh >= 0)
        {
            isSlider2 = true;
            
        }
        else { prueba = 0; }

        if (countDashh < 0) { StartCoroutine(countDash()); }

        Dash();
    }

    IEnumerator countDash()
    {
        yield return new WaitForSeconds(1);
        countDashh = 1;
        isSlider = false;
        isSlider2 = false;
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
           // body.AddForceAtPosition(transform.right, transform.position, ForceMode2D.Impulse);
           runSpeed
            countDashh -= Time.deltaTime;
        }

        if (isSlider2)
        {
            prueba = 1;
          //  body.AddForceAtPosition(-transform.right, transform.position, ForceMode2D.Impulse);
            countDashh -= Time.deltaTime;
        }
    }
}

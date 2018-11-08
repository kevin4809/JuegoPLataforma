using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{

    CharapterController controller;
    public Animator anim;
    public float runSpeed = 40f;
    float prueba;
    private float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Rigidbody2D body;

    public CircleCollider2D collider_Charapter;
    public BoxCollider2D dash_Collider_Charapter;

    private float direction;
    private float dashTime;
    public float dashSpeed;
    public float startDashTime;

    private void Start()
    {
        controller = GetComponent<CharapterController>();
        dash_Collider_Charapter.enabled = false;
    }

    void Update()
    {

        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        bool JumpingWall = stateinfo.IsName("Jump_Wall");
        bool heSlide = stateinfo.IsName("Dash");
        bool isFall = stateinfo.IsName("Down_Player");
        bool isUp = stateinfo.IsName("Up_Player");
        bool isAirAttack = stateinfo.IsName("Player_air_attack");

        if (!isFall && !isUp)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
       


        if (Input.GetButtonDown("Jump") && !heSlide ) { jump = true; }
        crouch = Input.GetButtonDown("Crouch") ? true : false;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (controller.m_Grounded && !JumpingWall && !isAirAttack) { anim.SetBool("Isjumping", false); } else { anim.SetBool("Isjumping", true); }
      
        Dash();

        

    }

    void Dash()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && direction == 0 && controller.m_Grounded)
        {
            if (controller.m_FacingRight) { direction = 1; }
            if (!controller.m_FacingRight) { direction = 2; }
        }

        if (direction == 1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * dashSpeed;
            dashTime -= Time.deltaTime;
            anim.SetBool("Isdash", true);
            dash_Collider_Charapter.enabled = true;
            collider_Charapter.isTrigger = true;

        }

        if (direction == 2)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * dashSpeed;
            dashTime -= Time.deltaTime;
            anim.SetBool("Isdash", true);
            dash_Collider_Charapter.enabled = true;
            collider_Charapter.isTrigger = true;

        }


        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            anim.SetBool("Isdash", false);
            dash_Collider_Charapter.enabled = false;
            collider_Charapter.isTrigger = false;
        }
    }

    void FixedUpdate()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


}

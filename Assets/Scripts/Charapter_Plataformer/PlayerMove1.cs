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

    float numJumps;
    float time_Recover;
    float save_RunSpeed;

    private GameMaster gm;


    private void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        transform.position = gm.lastChekPointPos;

        controller = GetComponent<CharapterController>();
        dash_Collider_Charapter.enabled = false;
        save_RunSpeed = runSpeed;
        
    }

    void Update()
    {

        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        bool JumpingWall = stateinfo.IsName("Jump_Wall");
        bool heSlide = stateinfo.IsName("Dash");
        bool isFall = stateinfo.IsName("Down_Player");
        bool isUp = stateinfo.IsName("Up_Player");
        bool isAirAttack = stateinfo.IsName("Player_air_attack");
        bool heIsDown = stateinfo.IsName("Down_Player");

        if ( !isUp && Time.timeScale == 1.0f)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        if (isFall)
        {
           
            runSpeed = 0;
            time_Recover = 1f;
        }

        time_Recover -= Time.deltaTime;
        if(time_Recover <= 0)
        {
            runSpeed = save_RunSpeed;
        }
       

        if (Input.GetButtonDown("Jump") && !heSlide && !PlayerAttack.isAttack) { jump = true; }
        crouch = Input.GetButtonDown("Crouch") ? true : false;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (controller.m_Grounded && !JumpingWall) {  anim.SetBool("Isjumping", false); } else if (!isAirAttack) { anim.SetBool("Isjumping", true); }


        if (isAirAttack)
        {
            anim.SetBool("Isjumping", false);
        }
        
      
        Dash();

        

    }

    void Dash()
    {
        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        bool heWalking = stateinfo.IsName("Walk_Player");

        if (Input.GetKeyDown(KeyCode.LeftShift) && direction == 0 && controller.m_Grounded && heWalking)
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

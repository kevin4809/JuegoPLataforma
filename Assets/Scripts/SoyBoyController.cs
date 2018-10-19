﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoyBoyController : MonoBehaviour
{

    public float speed = 14f;
    public float accel = 6f;
    private Vector2 input;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    public bool isJumping;
    public float jumpSpeed = 8f;
    public float rayCastLengthCheck = 0.005f;
    public float width;
    public float height;

    public float jumpDurationThreshold = 0.25f;
    private float jumpDuration;
    public float airAccel = 3f;

   public Animator anim;
    public float jump = 14f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;
    }



    public bool IsWallToLeftOrRight()
    {
 
        bool wallOnleft = Physics2D.Raycast(new Vector2(
        transform.position.x - width, transform.position.y),
        -Vector2.right, rayCastLengthCheck);
        bool wallOnRight = Physics2D.Raycast(new Vector2(
        transform.position.x + width, transform.position.y),
        Vector2.right, rayCastLengthCheck);
      
        if (wallOnleft || wallOnRight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool PlayerIsTouchingGroundOrWall()
    {
        if (PlayerIsOnGround() || IsWallToLeftOrRight())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetWallDirection()
    {
        bool isWallLeft = Physics2D.Raycast(new Vector2(
        transform.position.x - width, transform.position.y),
        -Vector2.right, rayCastLengthCheck);
        bool isWallRight = Physics2D.Raycast(new Vector2(
        transform.position.x + width, transform.position.y),
        Vector2.right, rayCastLengthCheck);
        if (isWallLeft)
        {
            return -1;
        }
        else if (isWallRight)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }


    void Update()
    {
        // 1
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Jump");
        // 2
        if (input.x > 0f)
        {
            sr.flipX = false;
        }
        else if (input.x < 0f)
        {
            sr.flipX = true;
        }

        if (PlayerIsOnGround() && isJumping == false)
        {
            if (input.y > 0f)
            {
                isJumping = true;
            }
        }

        if (jumpDuration > jumpDurationThreshold) input.y = 0f;
    }

    void FixedUpdate()
    {
        // 1
        var acceleration = 0f;
        if (PlayerIsOnGround())
        {
            acceleration = accel;
        }
        else
        {
            acceleration = airAccel;
        }
        var xVelocity = 0f;
        // 2
        if (PlayerIsOnGround() && input.x == 0)
        {
            xVelocity = 0f;
        }
        else
        {
            xVelocity = rb.velocity.x;
        }
        // 3
        var yVelocity = 0f;
        if (PlayerIsTouchingGroundOrWall() && input.y == 1)
        {
            yVelocity = jump;
        }
        else
        {
            yVelocity = rb.velocity.y;
        }
        rb.AddForce(new Vector2(((input.x * speed) - rb.velocity.x)
        * acceleration, 0));
        // 4
        rb.velocity = new Vector2(xVelocity, yVelocity);

        if (IsWallToLeftOrRight() && !PlayerIsOnGround()
 && input.y == 1)
        {
            rb.velocity = new Vector2(-GetWallDirection()
            * speed * 0.75f, rb.velocity.y);
            animator.SetBool("Isjumping", true);
            animator.SetBool("IsOnWall", false);
        }else if (!IsWallToLeftOrRight())
        {
            animator.SetBool("Isjumping", false);
            animator.SetBool("IsOnWall", true);
        }

        if (isJumping && jumpDuration < jumpDurationThreshold)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (input.y >= 1f)
        {
            jumpDuration += Time.deltaTime;
        }
        else
        {
            isJumping = false;
            jumpDuration = 0f;
        }

        
    }

    public bool PlayerIsOnGround()
    {
        // 1
        bool groundCheck1 = Physics2D.Raycast(new Vector2(
        transform.position.x, transform.position.y - height),
        -Vector2.up, rayCastLengthCheck);
        bool groundCheck2 = Physics2D.Raycast(new Vector2(
        transform.position.x + (width - 0.2f),
        transform.position.y - height), -Vector2.up,
        rayCastLengthCheck);
        bool groundCheck3 = Physics2D.Raycast(new Vector2(
        transform.position.x - (width - 0.2f),
        transform.position.y - height), -Vector2.up,
        rayCastLengthCheck);
        // 2
        if (groundCheck1 || groundCheck2 || groundCheck3)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
}
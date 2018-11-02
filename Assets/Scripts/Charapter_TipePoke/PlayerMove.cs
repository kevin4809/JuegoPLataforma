using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        if(mov != Vector2.zero)
        {
            anim.SetFloat("MovX", mov.x);
            anim.SetFloat("MovY", mov.y);
        }

        anim.SetBool("Walking", mov != Vector2.zero ? true : false);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}

    

  


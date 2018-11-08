using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{

    public float distance = 1f;
    CharapterController controller;
    public float speed = 2f;
    public float salt = 2f;
    bool walljumping;
    public Animator anim;
    public LayerMask layer;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharapterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, layer);
        //print(hit.transform.name);
        
        if (hit.collider)
        {
            anim.SetBool("Iswall", true);
            GetComponent<Rigidbody2D>().gravityScale = 2.2f;

          GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            anim.SetBool("Iswall", false);
            
        
        }

        if (controller.m_Grounded)
        {
            GetComponent<Rigidbody2D>().gravityScale = 3f;
        }

        if (hit.collider && Input.GetButtonDown("Jump"))
        {
            //controller.outsideForce = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * hit.normal.x, salt);
         
            //Debug.Log("Pared");
            StartCoroutine(TurnIt());
        }



    }

    IEnumerator TurnIt()
    {
        yield return new WaitForFixedUpdate();

        controller.Flip();

    }

}

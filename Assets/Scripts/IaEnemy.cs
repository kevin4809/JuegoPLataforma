using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaEnemy : MonoBehaviour {

    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public float distance;
    public float rangeVision;
    public Animator anim;
    public LayerMask layer;

    bool heIsWalkgin = true;

    int healt = 100;
    float dins = 5;
    int verfiHealt;


    //Attack
    bool isAttack;
    float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public int damage;
    public float speetInAttack;
    Rigidbody2D rb;
  

    private void Start()
    {
        healt = verfiHealt;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {

        if (heIsWalkgin)
        {
            if (movingRight) { transform.Translate(Vector2.right * speed * Time.deltaTime); }
            if (!movingRight)  { transform.Translate(Vector2.left * speed * Time.deltaTime); }

            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
       

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                movingRight = false;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                rb.velocity = Vector2.zero;
            }
            else
            {
                 transform.Translate(Vector2.left * speed * Time.deltaTime);
                movingRight = true;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
              rb.velocity = Vector2.zero;
            }
        }

        Attack();
        
	}

    public void TakeDamage(int damage)
    {

        healt -= damage;
        print("take");
        if (healt < verfiHealt)
        {
            healt = verfiHealt;
            anim.SetTrigger("HeDamage");
           // transform.Translate(Vector3.left * distance * Time.deltaTime);
        }



    }

    void Attack()
    {

        if (timeBtwAttack <= 0)
        {
            if (isAttack)
            {
                Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, layer);

                for (int i = 0; i < playerToDamage.Length; i++)
                {
                    playerToDamage[i].GetComponent<PlayerLive>().TakeDamage(damage);
                     
                   
                }
            }

            timeBtwAttack = startTimeBtwAttack;

        }
        else { timeBtwAttack -= Time.deltaTime; }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, rangeVision, layer);
        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        bool isAttaking = stateinfo.IsName("Attack_Enemy");
        if (hit.collider && !isAttaking)
        {
            isAttack = true;
            anim.SetTrigger("Isattack");
            if (movingRight)
            {

                StartCoroutine(countC());

            }
            else
            {

                StartCoroutine(countC2());
            }
        }
        else
        {
          
        }

        

      
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * rangeVision);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    IEnumerator countC()
    {
        yield return new WaitForSeconds(0.7f);
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speetInAttack;
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector2.zero;

    }

    IEnumerator countC2()
    {
        yield return new WaitForSeconds(0.7f);
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speetInAttack;
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector2.zero;
    }
}

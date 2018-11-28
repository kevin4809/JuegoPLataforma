using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaEnemy : MonoBehaviour
{

    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public float distance;
    public float rangeVision;
    public Animator anim;
    public LayerMask layer;

    bool heIsWalkgin = true;

    public int healt = 100;
    float dins = 5;

    //Attack
    bool isAttack;
    float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    bool heIsDeath = false;
    Collider2D enemyTrigger;

    public float speetInAttack;
    Rigidbody2D rb;

    public Collider2D sword;


    float rest;
    public float startRest;
    float speedTurn;

    //TargetPlayer
    private Transform target;
   

    private void Awake()
    {
        target = FindObjectOfType<PlayerAttack>().transform;
    }

    private void Start()
    {
        speedTurn = speed;
        rb = GetComponent<Rigidbody2D>();
        sword.enabled = false;
        enemyTrigger = GetComponent<Collider2D>();
    }

    void Update()
    {
      
        

        if (heIsWalkgin && !heIsDeath)
        {
            if (movingRight) { transform.Translate(Vector2.right * speed * Time.deltaTime); }
            if (!movingRight) { transform.Translate(Vector2.left * speed * Time.deltaTime); }

            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }


        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false && !heIsDeath)
        {

            turn();

        }

        Attack();

        if (healt <= 0)
        {

            anim.Play("Death_Enemy");
            heIsDeath = true;
            enemyTrigger.isTrigger = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0.1f;
            StartCoroutine(countC());

        }

        rest -= Time.deltaTime;

        
    }

    public void TakeDamage(int damage)
    {

        if (!heIsDeath)
        {
            print("take");
            healt -= damage;
            anim.SetTrigger("HeDamage");
            // transform.Translate(Vector3.left * distance * Time.deltaTime);
            rest = startRest;

            Vector3 distanceVector = target.position - transform.position;
            float distance = distanceVector.magnitude;

            if(distanceVector.x > 0 && !movingRight)
            {
                Debug.Log("aklhsfasf");
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(-transform.right * 100);
                StartCoroutine(CountRest());
            }
            else
            {
                if(distanceVector.x < 0 && movingRight)
                {
                    Debug.Log("alñfjsaf");
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.AddForce(transform.right * 100);
                    StartCoroutine(CountRest());
                }
            }
        }
    }
    void Attack()
    {

        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        bool isHurt = stateinfo.IsName("Hurt_Enemy");
        bool isAttaking = stateinfo.IsName("Attack_Enemy");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, rangeVision, layer);
        if (hit.collider && !isAttaking && rest <= 0)
        {
            
            isAttack = true;

            if (movingRight)
            {
                anim.SetTrigger("Isattack");
                StartCoroutine(countC());
                rest = startRest;
            }
            else
            {
                anim.SetTrigger("Isattack");
                StartCoroutine(countC2());
                rest = startRest;
            }
        }

        if (isAttaking)
        {
            enemyTrigger.enabled = false;
        }
        else
        {
            enemyTrigger.enabled = true;
        }

       

        if (isAttaking)
        {
            enemyTrigger.isTrigger = true;
        }
        else { enemyTrigger.isTrigger = false; }

     

        if (isAttaking)
        {
            timeBtwAttack += Time.deltaTime;

            if (timeBtwAttack >= startTimeBtwAttack)
            {
                sword.enabled = true;
                timeBtwAttack = 0;
            }
            else { timeBtwAttack += Time.deltaTime; }
        }
        else { sword.enabled = false; timeBtwAttack = 0; }



    }


    public void turn()
    {
        if (movingRight == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            movingRight = false;
            Vector3 theScale = transform.localScale; theScale.x *= -1; transform.localScale = theScale;
            rb.velocity = Vector2.zero;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            movingRight = true;
            Vector3 theScale = transform.localScale; theScale.x *= -1; transform.localScale = theScale;
            rb.velocity = Vector2.zero;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * rangeVision);

    }


    IEnumerator countC()
    {
        if (heIsDeath)
        {
            yield return new WaitForSeconds(0.8f);
            Destroy(gameObject);
        }
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

    IEnumerator CountRest()
    {
        yield return new WaitForSeconds(0.5f);
        rb.bodyType = RigidbodyType2D.Kinematic;
        turn();
        rest = 0;
    }

}

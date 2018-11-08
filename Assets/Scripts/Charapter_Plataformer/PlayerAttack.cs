using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    bool isAttack = false;
    public  bool isAttackAir = false;
    public CharapterController controller;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public float speedAttack;

    float timeBtwAttack;
    public float startTimeBtwAttack;

    float countAttack;
    public float StartCountAttack;

    float countAttackAir;
    public float StartCountAttackAir;

    private void Start()
    {
        controller = GetComponent<CharapterController>();
    }

    private void Update()
    {


        if (timeBtwAttack <= 0)
        {
            if (isAttack)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<IaEnemy>().TakeDamage(damage);
                }
            }

            timeBtwAttack = startTimeBtwAttack;

        }
        else { timeBtwAttack -= Time.deltaTime; }

        //isAttack = Input.GetButtonDown("Fire1") ? true : false;

        if (isAttack = Input.GetButtonDown("Fire1"))
        {
            countAttack = StartCountAttack;
        }
            if (countAttack >= 0)
        {
            isAttack = true;
            countAttack -= Time.deltaTime;

        }
        else { isAttack = false; }


        if (Input.GetButtonDown("Fire1") && !controller.m_Grounded)
        {
            
            countAttackAir = StartCountAttackAir;
        }
        if(countAttackAir >= 0)
        {
            isAttackAir = true;
            countAttackAir -= Time.deltaTime;
        }
        else
        {
            isAttackAir = false;
        }
               
            
        
     
       

        if (isAttack && controller.m_Grounded)
        {
            anim.SetBool("Isattack", true);
          GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, speedAttack);

        }
        else if(!isAttack)
        {
            anim.SetBool("Isattack", false);
        }

        if (isAttackAir)
        {
            anim.SetBool("Airattack", true);
          


        }
        else
        {
            anim.SetBool("Airattack", false);
        }
        


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

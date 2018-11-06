using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    bool isAttack = false;
    public CharapterController controller;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public float speedAttack;

    float timeBtwAttack;
    public float startTimeBtwAttack;

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

        isAttack = Input.GetButton("Fire1") ? true : false;
        if (isAttack && controller.m_Grounded)
        {
            anim.SetBool("Isattack", true);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, speedAttack);

        }
        else
        {
            anim.SetBool("Isattack", false);
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

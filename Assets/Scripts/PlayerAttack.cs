using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator anim;
    bool isAttack = false;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    float timeBtwAttack;
    public float startTimeBtwAttack;

    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (isAttack)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }

            timeBtwAttack = startTimeBtwAttack;

        }
        else { timeBtwAttack -= Time.deltaTime; }


        isAttack = Input.GetButton("Fire1") ? true : false;
        if (isAttack) { anim.SetBool("Isattack", true); } else { anim.SetBool("Isattack", false);}

   
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

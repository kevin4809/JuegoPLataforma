using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaGhost : MonoBehaviour
 {

public GameObject proyectile;
public Animator anim;
public Transform target;
public float range_Vision;
public static bool heIsRight;

private float timeBtwShot;
SpriteRenderer spriteRenderer;
public float startTimeBtwShots;

bool heIsDeath = false;

public float healt = 2000;
//public LayerMask layer;
void Awake()
{
	target = FindObjectOfType<PlayerAttack>().transform;
	spriteRenderer = GetComponent<SpriteRenderer>();
        GameMaster.countEnemy += 1;
}

void Update()
{
	 //Physics2D.OverlapCircleAll(enemy.position, range_Vision, layer);
	Vector3 distanceVector = target.position-transform.position;
	float distance = distanceVector.magnitude;
	

	if(timeBtwShot <= 0)
	{
        if(distance <= range_Vision && !heIsDeath)
		{
		 
        StartCoroutine(CountAttack());
		anim.SetTrigger("HeIsAttack");
		timeBtwShot = startTimeBtwShots;

		}

	}else
	{
		timeBtwShot -= Time.deltaTime;
	}
	

		if(distanceVector.x > 0 && !heIsDeath)
		{
          spriteRenderer.flipX = true;
		   heIsRight = true;
		}else
		{
			spriteRenderer.flipX = false;
			heIsRight = false;
		}

        if (healt <= 0)
        {
            heIsDeath = true;
            anim.Play("Death_ghost");
            StartCoroutine(CountAttack());
        }



        AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);
        bool Isattack = stateinfo.IsName("Touch_ghost");

        if (Isattack)
        {
            anim.SetBool("Isattack", false);
        }


    }


    public void TakeDamage ( int damage)
    {
        healt -= damage;
        anim.SetBool("Isattack", true);

    }



 IEnumerator CountAttack()
    {
        if (heIsDeath)
        {
            yield return new WaitForSeconds(0.5f);
            GameMaster.countEnemy -= 1;
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(1);
	  Instantiate(proyectile, transform.position, Quaternion.identity);
 }



  private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range_Vision);
    }
}

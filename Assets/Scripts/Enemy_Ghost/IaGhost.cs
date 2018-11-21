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

    public float healt = 100;
//public LayerMask layer;
void Awake()
{
	target = FindObjectOfType<PlayerAttack>().transform;
	spriteRenderer = GetComponent<SpriteRenderer>();
}

void Update()
{
	 //Physics2D.OverlapCircleAll(enemy.position, range_Vision, layer);
	Vector3 distanceVector = target.position-transform.position;
	float distance = distanceVector.magnitude;
	

	if(timeBtwShot <= 0)
	{
        if(distance <= range_Vision)
		{
		 
        StartCoroutine(CountAttack());
		anim.SetTrigger("HeIsAttack");
		timeBtwShot = startTimeBtwShots;

		}

	}else
	{
		timeBtwShot -= Time.deltaTime;
	}
	

		if(distanceVector.x > 0)
		{
          spriteRenderer.flipX = true;
		   heIsRight = true;
		}else
		{
			spriteRenderer.flipX = false;
			heIsRight = false;
		}
	
	    if(healt <= 0)
        {
           // Debug.Log("HeIsDeath");
        }
	
}


    public void TakeDamage ( int damage)
    {
        healt -= damage;
        Debug.Log("Daño");
    }
 

 IEnumerator CountAttack()
 {
	 yield return new WaitForSeconds(1);
	  Instantiate(proyectile, transform.position, Quaternion.identity);
 }



  private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range_Vision);
    }
}

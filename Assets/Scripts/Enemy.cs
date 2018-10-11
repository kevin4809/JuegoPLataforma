using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    int healt = 100;
    float dins = 5;
    int verfiHealt;

    float distance = 5;

    private void Start()
    {
        healt = verfiHealt;
    }
    public void TakeDamage(int damage)
    {
      
      healt -= damage;
        print("take");
        if (healt < verfiHealt)
        {
            healt = verfiHealt;
            anim.Play("Hurt_Enemy");
            transform.Translate(Vector3.left * distance * Time.deltaTime);
        }

        
      
    } 


	
}

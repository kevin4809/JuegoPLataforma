using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    public int healt = 100;
    public Animator anim;
         
   

    public void TakeDamage(int damage)
    {
        healt -= damage;
       
            print("AUSHHHH");
            anim.SetTrigger("Down");
;        
    }

    private void Update()
    {
        if(healt <= 0)
        {

        }
    }
}

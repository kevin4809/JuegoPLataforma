using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    public int healt = 100;
    int verfiHealt;
    public Animator anim;
         
    private void Start()
    {
        healt = verfiHealt;

    }

    public void TakeDamage(int damage)
    {
        healt -= damage;
        if(healt < verfiHealt)
        {
            healt = verfiHealt;
            print("AUSHHHH");
            anim.SetTrigger("Down");
;        }
    }
}

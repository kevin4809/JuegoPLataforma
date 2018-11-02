using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public PlayerLive playerLive;

    public int damage;


   
    void OnTriggerEnter2D(Collider2D col)
    {
     
        if (col.gameObject.CompareTag("Player"))
        {
            playerLive.TakeDamage(damage);
        }
    }

}

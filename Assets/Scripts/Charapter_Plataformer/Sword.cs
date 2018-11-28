using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private PlayerLive playerLive;

    public int damage;

    private void Awake()
    {
        playerLive = FindObjectOfType<PlayerAttack>().GetComponent<PlayerLive>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
     
        if (col.gameObject.CompareTag("Player"))
        {
            playerLive.TakeDamage(damage);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikes : MonoBehaviour {

    private PlayerLive player;

    public void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerLive>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(player.Knockback(0.01f, 350, player.transform.position));
            print("IsTouching");
        }
    }
}

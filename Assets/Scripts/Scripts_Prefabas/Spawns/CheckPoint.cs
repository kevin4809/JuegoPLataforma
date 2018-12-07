using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    public Transform player;
    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastChekPointPos = transform.position;
            player.transform.position = gm.lastChekPointPos;
            print("Hola");
        }
    }

}

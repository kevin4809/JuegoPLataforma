using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pss : MonoBehaviour {

    private Transform tp;
    private Transform player;

    private void Start()
    {
        tp = GameObject.Find("TP").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = tp.transform.position;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlayer : MonoBehaviour {

    private Transform tp;
    private Transform player;

    private void Start()
    {
        tp = GameObject.Find("CheckPoint").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
     
    }
}

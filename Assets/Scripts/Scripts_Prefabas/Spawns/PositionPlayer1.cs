﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlayer1 : MonoBehaviour {

    private Transform tp;
    private Transform player;

    private void Start()
    {
        tp = GameObject.Find("FirstCheckPoint").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();

        player.transform.position = tp.transform.position;
    }
}
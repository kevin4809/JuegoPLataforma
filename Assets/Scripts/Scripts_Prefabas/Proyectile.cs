﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour 
{
public float speed;
private Transform player;
private Vector2 target; 

private SpriteRenderer spriteFlip;

private Vector3 targetPos;
private Vector3 thispos;
private float angle;
private float offset;

void Start()
{
	player = GameObject.FindGameObjectWithTag("Player").transform;
	target = new Vector2(player.position.x, player.position.y);
	spriteFlip = GetComponent<SpriteRenderer>();

	targetPos = player.position;
     thispos = transform.position;
     targetPos.x = targetPos.x - thispos.x;
     targetPos.y = targetPos.y - thispos.y;
     angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

	 if(IaGhost.heIsRight)
	 {
       spriteFlip.flipY = false;
	 }else
	 {
		 spriteFlip.flipY = true;
	 }
}

void Update()
{
	transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
	if(transform.position.x == target.x && transform.position.y == target.y)
	{
		DestroyProyectile();
	}


	
	
}
 


void DestroyProyectile()
{
	Destroy(gameObject);
}
	
}
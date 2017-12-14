using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	public Vector2 target;
	public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(transform.position, target, speed);
		if(transform.position.x == target.x && transform.position.y == target.y) Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag != "Player") Destroy(gameObject);
	}
}

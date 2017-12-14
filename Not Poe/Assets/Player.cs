using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D body; Animator anim;
	public GameObject aim;
	float movementSpeed = 100;
	Vector3 cameraOffset;
	public GameObject projectile;
	void Start () {
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		cameraOffset = Camera.main.transform.position - transform.position;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		aim.transform.position = new Vector3(point.x, point.y, aim.transform.position.z);
		body.velocity = Vector2.zero;
		if(Input.GetKey(KeyCode.UpArrow))
			body.AddForce(Vector2.up*movementSpeed);
		if(Input.GetKey(KeyCode.DownArrow))
			body.AddForce(Vector2.down*movementSpeed);
		if(Input.GetKey(KeyCode.RightArrow))
			body.AddForce(Vector2.right*movementSpeed);
		if(Input.GetKey(KeyCode.LeftArrow))
			body.AddForce(Vector2.left*movementSpeed);
		Camera.main.transform.position = transform.position + cameraOffset;
		if(Input.GetMouseButtonDown(0))
		{
			GameObject g = Instantiate(projectile, transform.position, Quaternion.identity);
			Projectile proj = g.GetComponent<Projectile>();
			proj.speed = .25f;
			proj.target = aim.transform.position;
		}
	}
}

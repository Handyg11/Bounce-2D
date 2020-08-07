using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {
	
	float moveSpeed = 7f;

	Rigidbody2D rb;

	private BallController balls;
	Vector2 moveDirection;
	private BallHealth ballHealth;
	private GameMaster gm;

	// Use this for initialization
	
	
	// Update is called once per frame
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		balls = GameObject.FindObjectOfType<BallController>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		ballHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<BallHealth>();
		moveDirection = (balls.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, 3f);
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name.Equals ("bola")) {
			ballHealth.Damage(1);
			rb.velocity = new Vector2(0.0f,0.0f);
			gm.TriggerRespawn();
			Destroy (gameObject);
			ballHealth.transform.position = gm.lastCheckPointPos;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	Rigidbody2D rb2d;
	GameObject target;
	Vector3 directionToTarget;
	public float moveSpeed = 2.0f;
	bool following = false;

	void Start(){
		rb2d=GetComponent<Rigidbody2D>();
		target = GameObject.Find("ballDetection");
	}
	
	// Update is called once per frame
	void Update () {
		if(following){
			directionToTarget = (target.transform.position - transform.position).normalized;
			rb2d.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * 0);
		}
		else rb2d.velocity = Vector2.zero;
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
		following = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.CompareTag("Player")){
		following = false;
		}
	}
}

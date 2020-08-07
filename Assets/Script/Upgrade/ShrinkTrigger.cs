using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkTrigger : MonoBehaviour {

	private BallController ball;
	private Rigidbody2D rb;
	private GameMaster bp;
	public PhysicsMaterial2D physics;


	void Start(){
		bp = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();

	}

	void Awake(){
		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	void OnCollisionEnter2D(Collision2D coli){
		if(coli.transform.CompareTag("Player")){
			ball.transform.localScale = new Vector3(0.5f, 0.5f,0f);
			bp.isBallCurrentlyLarge=false;
			physics.bounciness = 0.45f;
			ball.jumpHeight = 3.0f;
		}
	}
}

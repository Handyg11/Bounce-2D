using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour {
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
			ball.transform.localScale = new Vector3(0.57f, 0.57f,0f);
			bp.isBallCurrentlyLarge=true;
			physics.bounciness = 0.5f;
			ball.jumpHeight = 4.0f;
		}
	}

}

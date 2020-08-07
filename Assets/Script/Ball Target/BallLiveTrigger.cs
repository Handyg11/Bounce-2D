using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLiveTrigger : MonoBehaviour {
	private BallHealth ball;

	private Rigidbody2D rb;
	private BallController balls;
	private GameMaster bp;
	void Start(){
		bp = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallHealth>();

	}

	void Awake(){
		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	void OnTriggerEnter2D(Collider2D coli){
		if(coli.CompareTag("Player")){
			ScoreScript.scoreValue += 300;
			ball.Add(1);
			Destroy(this.gameObject);
		}

	}
}

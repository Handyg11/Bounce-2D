using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesTrigger : MonoBehaviour {
	private BallHealth ball;

	private Rigidbody2D rb;
	private BallController balls;
	private GameMaster bp;
	public PhysicsMaterial2D physics;

	void Start(){
		bp = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallHealth>();

	}

	void Awake(){
		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	void OnTriggerEnter2D(Collider2D coli){
		if(coli.CompareTag("Player")){
			ball.Damage(1);
			rb.velocity = new Vector2(0.0f,0.0f);
			//Debug.Log(bp.lastCheckPointPos);
			bp.TriggerRespawn();
			ball.transform.position = bp.lastCheckPointPos;
		}
	}

}

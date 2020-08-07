using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	private static GameMaster instance;
	public Vector2 lastCheckPointPos;
	public PhysicsMaterial2D physics;
	private BallController ball;
	public bool isBallActuallyLarge = false;
	public bool isBallCurrentlyLarge =false;
	// Use this for initialization
	void Awake () {
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(instance);
		}else{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		ball = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
		lastCheckPointPos = GameObject.FindGameObjectWithTag("Player").transform.position;

		//Debug.Log("STARTING");
	}
	public void TriggerRespawn() {
		if(isBallActuallyLarge == false){
			ball.transform.localScale = new Vector3(0.5f, 0.5f,0f);
			physics.bounciness = 0.45f;
			ball.jumpHeight = 3.0f;
		}else{
			ball.transform.localScale = new Vector3(0.57f, 0.57f,0f);
			physics.bounciness = 0.5f;
			ball.jumpHeight = 4.0f;
		}
	}
}

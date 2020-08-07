using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour {


	Rigidbody2D rb2d;
	GameObject target;
	public float moveSpeed = 2.0f;
	bool following = false;

	[SerializeField]
	GameObject bullet;

	float fireRate;
	float nextFire;

	void Start(){
		rb2d=GetComponent<Rigidbody2D>();
		target = GameObject.Find("ballDetection");
		fireRate = 1f;
		nextFire = Time.time;
		Debug.Log(target);
		following = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
		CheckIfTimeToFire ();
		}
	}
	void OnTriggerExit2D(Collider2D col){
		//following = false;
	}
	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire) {
			Instantiate (bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}
		
	}
}



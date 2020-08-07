using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {
	public Vector2 speed;
	public float delay;
	Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.velocity = speed;
		//rb2d.isKinematic = true;
		Destroy(gameObject, delay);
		}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = speed;
		}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Enemy")){
			ScoreScript.scoreValue += 500;
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		if(other.gameObject.CompareTag("Block")){
			Destroy(gameObject);
		}
	}
	/*void OnCollisionEnter2D(Collision2D other){
		Debug.Log("Masuk");
		if(other.gameObject.CompareTag("Untagged")){
			Destroy(gameObject);
		}
		if(other.gameObject.CompareTag("Block")){
			Destroy(gameObject);
		}
	} */
}

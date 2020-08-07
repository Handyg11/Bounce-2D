using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {
 public Transform[] waypoints;
private bool movingRight = true;
    int cur = 0;
	public int speed = 2;

	void FixedUpdate () {

		if (transform.position != waypoints[cur].position) {
			Vector2 go = Vector2.MoveTowards(transform.position,
											waypoints[cur].position,
											speed*Time.deltaTime);
			GetComponent<Rigidbody2D>().MovePosition(go);
		}
		
		
		else {cur = (cur + 1) % waypoints.Length;
		if(movingRight == true){
				transform.eulerAngles = new Vector3(0,180,0);
				movingRight = false;
			}
			else{
				transform.eulerAngles = new Vector3(0,0,0);
				movingRight = true;
			}
		}
		
	}
}

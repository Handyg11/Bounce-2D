using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingScript : MonoBehaviour
{
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
		
		
		else {cur = (cur + 1) % waypoints.Length;}}


    // public float stoppingDistance;
    // private Transform target;

    // // Use this for initialization
    // void Start()
    // {
    //     target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
    //     {
    //         transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    //     }

    // }
}

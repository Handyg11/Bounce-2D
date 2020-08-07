using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingTrigger : MonoBehaviour {

	private RingCounter ring;

	private Rigidbody2D rigbody;

	private GameMaster bp;

	public Color color;

	public CapsuleCollider2D coli;

	public SpriteRenderer spriteDepan;
	public SpriteRenderer spriteBelakang;
	public float grayscale;
	void Start(){
		bp = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		ring = GameObject.FindGameObjectWithTag("Player").GetComponent<RingCounter>();
		coli = GetComponent<CapsuleCollider2D>();
		
	}

	void Awake(){
		rigbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	void OnTriggerEnter2D(Collider2D coli){
		//coli = GameObject.FindGameObjectWithTag("Ring").GetComponent<CapsuleCollider2D>();
		if(coli.CompareTag("Player")){
				ScoreScript.scoreValue += 500;
				spriteDepan.color= new Color(0.3F, 0.3F, 0.3F);
				spriteBelakang.color= new Color(0.3F, 0.3F, 0.3F);
				this.coli.enabled = false;

			ring.Delete(1);
		}
	}
}

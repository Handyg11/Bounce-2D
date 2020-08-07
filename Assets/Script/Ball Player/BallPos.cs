using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallPos : MonoBehaviour {
	private GameMaster gm;
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		transform.position = gm.lastCheckPointPos;
	}
	void Update(){
		//ngetes cekpoint kalau mati
		if(Input.GetKeyDown (KeyCode.PageUp)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

}

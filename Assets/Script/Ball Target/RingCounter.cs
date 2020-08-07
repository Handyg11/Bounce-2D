using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RingCounter : MonoBehaviour {

public int rings; // currHealth
public int numOfRings; //maxHealth

public Image[] ringImage;
public Sprite fullRings;
public Sprite emptyRings;
public FinishScript finishScript;


	// Use this for initialization
	void Start () {
		rings = numOfRings;
		finishScript= GameObject.Find("finish").GetComponent<FinishScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rings > numOfRings){
			rings = numOfRings;
		}
		for(int i=0; i<ringImage.Length; i++){
			if(i < rings){
				ringImage[i].sprite = fullRings;
			}else{
				ringImage[i].sprite = emptyRings;
			}
			if(i<numOfRings){
				ringImage[i].enabled = true;
			}else{
				ringImage[i].enabled = false;
			}
		}

		if(rings == 0){
			//FinishScript.instance.Finish(); //ring trigger belom kelar
			//finishScript.Finish();
			//SceneManager.LoadScene(0);
		}
	}
	public void Delete(int masuk){
		numOfRings -= masuk;
	}

}

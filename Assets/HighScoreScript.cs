using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

	// Use this for initialization
	    Text finishScore;
    	public  static int finalScoreValue = 0;
		
	void Start(){
        finishScore = GetComponent<Text>();
    } 
    void Update(){
		finalScoreValue= ScoreScript.scoreValue;
        finishScore.text = "Your Score: "+ finalScoreValue;
    }
}

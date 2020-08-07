using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

	public static LevelControlScript instance = null;
	int sceneIndex, lvlPassed;
	//public GameObject finishPanel, gameOverPanel;


	// Use this for initialization
	void Start () {
		if(instance == null) instance = this;
		else if(instance != this) Destroy(gameObject);
		// finishPanel = GameObject.Find("FinishPanel");
		// gameOverPanel = GameObject.Find("GameOverPanel");

		sceneIndex= SceneManager.GetActiveScene().buildIndex;
		lvlPassed = PlayerPrefs.GetInt("LevelPassed");
		//Debug.Log(lvlPassed);
	}

	public void youWin(){
		if(sceneIndex == 6)loadMainMenu();
		else{
			if(lvlPassed < sceneIndex){
				PlayerPrefs.SetInt("LevelPassed",sceneIndex);
				Debug.Log("Passed");
				}
		}
	}

	public void youLose(){
		loadMainMenu();
	}
	
	public void loadNextLevel(){
		SceneManager.LoadScene(sceneIndex + 1);
	}

	void loadMainMenu(){
		SceneManager.LoadScene("Menu");
	}
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Button lvl02Button, lvl03Button, lvl04Button, lvl05Button, lvl06Button;
	int passedLvl;

	void Start(){
		Time.timeScale = 1f;
		passedLvl = PlayerPrefs.GetInt("LevelPassed");
		lvl02Button.interactable = false;
		lvl03Button.interactable = false;
		lvl04Button.interactable = false;
		lvl05Button.interactable = false;
		lvl06Button.interactable = false;

		switch(passedLvl){
			case 1:
			lvl02Button.interactable = true;
			break;
			case 2:
			lvl02Button.interactable = true;
			lvl03Button.interactable = true;
			break;
			case 3:
			lvl02Button.interactable = true;
			lvl03Button.interactable = true;
			lvl04Button.interactable = true;
			break;
			case 4:
			lvl02Button.interactable = true;
			lvl03Button.interactable = true;
			lvl04Button.interactable = true;
			lvl05Button.interactable = true;
			break;
			case 5:
			lvl02Button.interactable = true;
			lvl03Button.interactable = true;
			lvl04Button.interactable = true;
			lvl05Button.interactable = true;
			lvl06Button.interactable = true;
			break;
		}
	}

	public void lvlToLoad(int level){
		SceneManager.LoadScene(level);
	}
	public void resetPlayerPrefs()
	{
		lvl02Button.interactable = false;
		lvl03Button.interactable = false;
		lvl04Button.interactable = false;
		lvl05Button.interactable = false;
		lvl06Button.interactable = false;
		PlayerPrefs.DeleteAll ();
	}
public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishScript : MonoBehaviour
{
    //public static FinishScript instance = null;
    public static bool GameIsFreeze = false;
    public GameObject FinishPanelUI;

    public void OnTriggerEnter2D(Collider2D col)
    {
        Finish();
    }

    public void Finish()
    {
        LevelControlScript.instance.youWin();
        FinishPanelUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsFreeze = true;

    }

    public void proceedNextLevel()
    {
        Time.timeScale = 1f;
        GameIsFreeze = false;
        //Invoke("loadNextLevel",1f);
        LevelControlScript.instance.loadNextLevel();
    }
    public void restartLevel()
    {
        Time.timeScale = 1f;
        GameIsFreeze = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart
    }
    public void selectMenu()
    {
        Time.timeScale = 1f;
        GameIsFreeze = false;
        SceneManager.LoadScene(0);
    }
}

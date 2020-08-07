using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallHealth : MonoBehaviour
{

    public int health; // currHealth
    public int numOfBalls; //maxHealth

    public Image[] balls;
    public Sprite fullBall;
    public Sprite emptyBall;

    public int healthLimit = 5;

    public static bool GameIsFreeze = false;
	public GameObject GameOverPanelUI;


    // Use this for initialization
    void Start()
    {
        health = numOfBalls;
        startLevel();
    }

    // Update is called once per frame
    void Update()
    {

        if (health > numOfBalls)
        {
            health = numOfBalls;
        }
        for (int i = 0; i < balls.Length; i++)
        {
            if (i < health)
            {
                balls[i].sprite = fullBall;
            }
            else
            {
                balls[i].sprite = emptyBall;
            }
            if (i < numOfBalls)
            {
                balls[i].enabled = true;
            }
            else
            {
                balls[i].enabled = false;
            }
        }
        if (health == 0)
        {
            GameOver();
        }
    }
    public void Damage(int damage)
    {
        numOfBalls -= damage;
        health -= damage;
    }

    public void Add(int heal)
    {
        numOfBalls += heal;
        health += heal;

        if (numOfBalls >= 5)
        {
            numOfBalls = healthLimit;
        }
    }

       public void GameOver()
    {
        GameOverPanelUI.SetActive(true);
        Time.timeScale=0f;
        GameIsFreeze = true;
    }

    public void startLevel(){
        Time.timeScale = 1f;
        GameIsFreeze = false;
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart
    }
    public void selectMenu()
    {
        LevelControlScript.instance.youLose();
    }
}

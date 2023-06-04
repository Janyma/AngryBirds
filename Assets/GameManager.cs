using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject EndingScreen;
    public static GameManager GM;
    public int enemyCount;
    int startingCount;
    public Image star1;
    public Image star2;
    public Image star3;
    public Sprite goldenstar;
    public bool GameOver =false;


    // Start is called before the first frame update
    void Start()
    {
        GM=this;
        enemyCount= Enemy.EnemiesAlive;
        startingCount=enemyCount;
        GameOver = false;
        
    }

    private void SetStarsAmount(int stars, int levelIndex)
    {
        if(PlayerPrefs.GetInt("level" +levelIndex.ToString() + "stars", 0) <stars)
        {
            
            PlayerPrefs.SetInt("level" +levelIndex.ToString() + "stars", stars);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver)
        {
            enemyCount=Enemy.EnemiesAlive;
            EndingScreen.SetActive(true);
            int currentLevel=SceneManager.GetActiveScene().buildIndex;
            if(enemyCount <=2)
            {
                star1.sprite=goldenstar;
                SetStarsAmount(1, currentLevel);
            }
            if(enemyCount <=1)
            {
                star2.sprite=goldenstar;
                SetStarsAmount(2, currentLevel);
            }

            if(enemyCount ==0)
            {
                star3.sprite=goldenstar;
                SetStarsAmount(2, currentLevel);
                PlayerPrefs.SetInt("levelbeaten", currentLevel);
            }
            Enemy.EnemiesAlive=0;
            GameOver=false;


        }
        
    }

    public void OnClickMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

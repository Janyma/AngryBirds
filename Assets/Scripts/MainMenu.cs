using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject[] lockButton;
    public Image[] level1Star;
    public Image[] level2Star;
    public Sprite goldenstar;

//Levels lösen
    private void DeactivateLockButtons()
    {
        int levelbeaten=PlayerPrefs.GetInt("levelbeaten", 0);
        for(int i=0; i<levelbeaten; i++)
        {
            if(levelbeaten> 0)
                lockButton[i].SetActive(false);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        DeactivateLockButtons();

        int i=0;
        while (PlayerPrefs.GetInt("level1stars", 0) !=i)
        {
            level1Star[i].sprite = goldenstar;
            i++;
            
        }
        int j=0;
        while (PlayerPrefs.GetInt("level1stars", 0) !=j)
        {
            level2Star[j].sprite = goldenstar;
            j++;
            
        }
        
    }
    public void  OnClickLevelOne()
    {
        SceneManager.LoadScene(1);

    }
    public void  OnClickLevelTwo()
    {
        SceneManager.LoadScene(2);
  
    }

    
}

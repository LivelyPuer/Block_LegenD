using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameInPause = false;
    public bool GameInInventory = false;
    public bool InMenu = false;
    public GameObject Inventory;
    public GameObject PauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        if (InMenu == false)
        {
            PauseMenuUI.SetActive(false);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InMenu == false)
            {
                if (GameInInventory == false && GameInPause == false)
                {
                    Inventory.SetActive(true);
                    GameInInventory = true;
                }
                else
                {
                    Inventory.SetActive(false);
                    GameInInventory = false;
                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InMenu == false)
            {
                if (GameInPause == false)
                {
                    GamePause();
                    GameInPause = true;
                }
                else
                {
                    Continue();
                    GameInPause = false;
                }
            }
            
        }
    }

    public void LoadLevel(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    } 

    public void GamePause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Quit_Game()
    {
        Application.Quit();
    }

}

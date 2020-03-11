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
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InMenu == false)
            {
                GameInInventory = !GameInInventory;
                if (GameInInventory && GameInPause == false)
                {
                    Inventory.SetActive(true);
                }
                else if (GameInInventory == false || GameInPause)
                {
                    Inventory.SetActive(false);
                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InMenu == false)
            {
                GameInPause = !GameInPause;
                if (GameInPause == false)
                {
                    GamePause();
                }
                else
                {
                    Continue();
                }
            }
            
        }
    }

    public void LoadLevel(int level)
    {
        Debug.Log("Выбираем уровень: " + level);
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

    public void InInventory()
    {
        GameInInventory = !GameInInventory;
    }
}


using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    #region Variables
    public static bool isPaused;
    public GameObject pausePanel;
    public GameObject player;
    public PLAYER playerScript;


    

    #endregion
    #region Start
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        pausePanel.SetActive(false);
        playerScript = player.GetComponent<PLAYER>();


    }
    #endregion
    #region Update
    void Update()
    {
        if (playerScript.dead == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenuActive();
            }
        }
    }
    #endregion
    #region Pause Menu
    public void PauseMenuActive()
    {
        
        isPaused = !isPaused;
        Debug.Log(isPaused);

        //Bring up menu and pause game when paused
        if (isPaused)
        {

            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pausePanel.SetActive(true);
            
        }
        //Remove menu and unpause game 
        else
        {
           
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pausePanel.SetActive(false);
        }
    }
    #endregion


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool playerIsActive = false;
    public GameObject MenuPanel;
    public GameObject AfterMenu;
    public GameObject Gameover;   
    public int EnemyCounter= 0; 

    private void Start()
    {
        AfterMenu.SetActive(false);
        Gameover.SetActive(false);
    }
    public void PlayGame()
    {
        playerIsActive = true;
        MenuPanel.SetActive(false);
        AfterMenu.SetActive(true);
    }

    public void PauseGame()
    {
        playerIsActive= false;  
    }

    public void checkEnem()
    {
        if (EnemyCounter > 2)
        {
            Gameover.SetActive(true);
            playerIsActive = false;
        }
    }
}

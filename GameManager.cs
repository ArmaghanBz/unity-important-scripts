using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] levels;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("lvl"))
        {
            PlayerPrefs.SetInt("lvl", 0);
        }
    }

    private void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("lvl");

        if (currentLevel <= levels.Length - 1) 
        {
            levels[currentLevel].SetActive(true);
            PlayerPrefs.SetInt("lvl", currentLevel + 1);
            print(PlayerPrefs.GetInt("lvl"));

        }
        else 
        {
            int randomLevel = Random.Range(0, 4);
            levels[randomLevel].SetActive(true);
            PlayerPrefs.SetInt("lvl", randomLevel);
            print(PlayerPrefs.GetInt("lvl"));
        }

        
    }
}

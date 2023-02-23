using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    public GameObject[] planes;
    public int currentPlaneIndex = 0;
    public int coinsCollected = 0;
    public bool isLeftRight;

    public CountDownUI countdownUI;


    void Start()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            planes[i].SetActive(i == 0);
        }
        isLeftRight = true;
        countdownUI = FindObjectOfType<CountDownUI>();
    }

    void Update()
    {
        if (coinsCollected >= 2)
        {
            currentPlaneIndex++;
            if (currentPlaneIndex >= planes.Length)
            {
                currentPlaneIndex = 0;
            }
            planes[currentPlaneIndex].SetActive(true);
            planes[currentPlaneIndex - 1].SetActive(false);
            coinsCollected = 0;

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsCollected++;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("greenWall"))
        {
            print("Exit");
            coinsCollected += 2;
            other.GetComponent<Collider>().enabled = false; 
        }
        else if (other.gameObject.CompareTag("redWall"))
        {
            coinsCollected -= 1;
            other.GetComponent<Collider>().enabled = false;

        }
        else if (other.gameObject.CompareTag("endPoint"))
        {
            isLeftRight = false;
            countdownUI.StartCountdown();
            Destroy(other.gameObject);
        }
    }

    
}

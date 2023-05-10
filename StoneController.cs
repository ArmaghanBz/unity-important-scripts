using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    public float moveAmount;
    public ParticleSystem particalSys;
    public GameObject arrow;
    public int stoneCounter = 0;
    
    private void Start()
    {
        arrow.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (stoneCounter != 10)
        {
            if (other.gameObject.CompareTag("Cube"))
            {
                ParticleSystem clone = Instantiate(particalSys, other.transform.position, Quaternion.identity);
                other.transform.Translate(Vector3.up * moveAmount, Space.World);
                other.tag = "picked";
                Destroy(clone.gameObject, 3f);
                stoneCounter++;
            }
        }
        else
        {

            arrow.SetActive(true);

        }

        
    }
    
}

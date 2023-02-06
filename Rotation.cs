using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 0, 0); 
    }
}

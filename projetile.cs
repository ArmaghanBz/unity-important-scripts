using System.Collections.Generic;
using UnityEngine;

public class projetile : MonoBehaviour
{
    public float life = 5f;

    void Awake()
    {
        Destroy(gameObject, life);
    }
}
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private Transform transformPosition;
    private NavMeshAgent navMesh;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (navMesh.enabled == true)
        {
            navMesh.destination = transformPosition.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform transformPosition;
    private NavMeshAgent navMesh;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        navMesh.destination = transformPosition.position;
    }

}

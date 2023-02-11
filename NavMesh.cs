using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [SerializeField] private Transform transformPosition;
    private NavMeshAgent navMesh;
    //Animator anime;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        //anime= GetComponent<Animator>();
    }
    private void Update()
    {
        if (navMesh.enabled == true)
        {
            //anime.SetBool("isWalking", true);
            navMesh.destination = transformPosition.position;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LaunchProjectile : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float launchVelocity = 5f;
    private GameObject player;
    public float maxThrowDistance = 5f;
    public bool hasThrown = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (!hasThrown && distanceToPlayer <= maxThrowDistance)
        {
            var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = launchPoint.up * launchVelocity;
            hasThrown = true;
        }
        else if (hasThrown && distanceToPlayer > maxThrowDistance)
        {
            hasThrown = false;
        }
    }
}
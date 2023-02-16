using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceDirection : MonoBehaviour
{
    public float force;
    public bool isTrue = false;
    

    private void Start()
    {
        isTrue = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isTrue= true;   
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) return;

        Rigidbody otherRb = collision.rigidbody;
        if (otherRb == null) return;

        Vector3 direction = otherRb.position - rb.position;
        direction.Normalize();
      
        rb.AddForce(-direction * force, ForceMode.Force);
        otherRb.AddForce(direction * force, ForceMode.Force);
        
        

    }
    
}

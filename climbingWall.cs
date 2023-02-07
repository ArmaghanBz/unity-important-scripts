using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class climbingWall : MonoBehaviour
{
    private Rigidbody rb;
    private bool isClimbing = false;
    public Animator anim;
    public float climbSpeed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (isClimbing)
        {
            transform.position += Vector3.up * climbSpeed * Time.deltaTime;
            anim.SetBool("isClimbing", true);
        }
        else
        {
            anim.SetBool("isClimbing", false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            isClimbing = true;
            GetComponent<NavMeshAgent>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        if (collision.gameObject.name == "ClambOut")
        {
            isClimbing = false;
            GetComponent<NavMeshAgent>().enabled = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}


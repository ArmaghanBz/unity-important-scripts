using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    Rigidbody m_Rigidbody;
    public float m_Speed = 20f;
    public bool isMove;
    public float force = 100f;
    private Menu menuScript;
    private Menu counter;
    void Start()
    {
        menuScript = FindObjectOfType<Menu>();
        counter = FindObjectOfType<Menu>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (menuScript.playerIsActive == true)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            horizontal = horizontal * -1;
            vertical = vertical * -1;

            Vector3 m_Input = new Vector3(horizontal, 0, vertical);
            if (isMove == true)
            {
                m_Rigidbody.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * m_Speed);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Renderer wallRenderer = other.gameObject.GetComponent<Renderer>();
            Renderer playerRenderer = GetComponent<Renderer>();
            Collider wall = other.gameObject.GetComponent<Collider>();

            if (wallRenderer.material.color == playerRenderer.material.color)
            {
                wall.isTrigger = true;
            }
            else if (wallRenderer.material.color != playerRenderer.material.color)
            {
                isMove = false;
                Vector3 forceDirection = (other.transform.position - transform.position).normalized;
                GetComponent<Rigidbody>().AddForce(-forceDirection * force, ForceMode.Impulse);
            }
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Material enemyMaterial = other.gameObject.GetComponent<Renderer>().material;
            GetComponent<Renderer>().material = enemyMaterial;
            Destroy(other.gameObject);
            counter.EnemyCounter++;
            counter.checkEnem();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Collider wall = collision.gameObject.GetComponent<Collider>();
            wall.isTrigger = false;
            isMove = true;

        }
    }
}

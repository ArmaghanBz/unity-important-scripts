using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick fJ;
    public GameObject[] tools;
    // [SerializeField] private Animator anime;

    private void Start()
    {
        tools[0].SetActive(true);
        tools[1].SetActive(false);
    }

    [SerializeField] private float movement;
    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(fJ.Horizontal, 0f, fJ.Vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);

            rb.MovePosition(rb.position + transform.forward * movement * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("toolChange"))
        {
            int i = 0;
            tools[i].SetActive(false);
            tools[i + 1].SetActive(true);
        }
    }
}

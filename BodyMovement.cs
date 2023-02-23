using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    public float speed;
    public float leftLimit = -2.36f;
    public float rightLimit = 2.36f;
    public float zSpeed;
    public float maxTiltAngle = 45f;
    PlaneManager obj;

    private void Start()
    {
        obj = GetComponent<PlaneManager>();
    }
    void Update()
    {
        if (obj.isLeftRight == true)
        {
            if (Input.GetMouseButton(0))
            {
                float inputX = Input.GetAxis("Mouse X");
                Vector3 position = transform.position;
                position.x += inputX * speed * Time.deltaTime;
                position.x = Mathf.Clamp(position.x, leftLimit, rightLimit);
                transform.position = position;
                float tiltAngle = -inputX * maxTiltAngle;
                Quaternion targetTilt = Quaternion.Euler(0f, 0f, tiltAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetTilt, 0.1f);
                transform.Translate(Vector3.forward * zSpeed * Time.deltaTime);
            }

        }else 
        {
            Vector3 position = transform.position;
            position.x = 0f;
            transform.position = position;
        }
    }
}

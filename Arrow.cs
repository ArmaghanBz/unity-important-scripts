using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform targetTransform;
    public float rotationSpeed = 5f;

    private void Update()
    {
        transform.LookAt(targetTransform);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}

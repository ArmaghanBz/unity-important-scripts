using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deltaPosition : MonoBehaviour
{
    Vector3 currentMousePosition, lastMousePosition,deltaMousePosition;
    public float distance;
    public forceDirection fd;
    public GameObject sphere1;
    public GameObject sphere2;

    private Rigidbody sphere1Rigid;
    private Rigidbody sphere2Rigid;

    void Start()
    {
        sphere1Rigid = sphere1.GetComponent<Rigidbody>();
        sphere2Rigid= sphere2.GetComponent<Rigidbody>();    
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            deltaMousePosition = lastMousePosition - Input.mousePosition;
            if (deltaMousePosition != Vector3.zero)
            {
                if (fd.isTrue == false)
                {
                    Vector3 direction = sphere2.transform.position - sphere1.transform.position;
                    direction.Normalize();
                    sphere1Rigid.AddForce(direction * fd.force, ForceMode.Force);
                    sphere2Rigid.AddForce(-direction * fd.force, ForceMode.Force);
                }
                else
                {
                    distance = deltaMousePosition.magnitude;
                    print("Move: " + distance.ToString());
                    fd.force += 20*distance * Time.deltaTime;
                }
                lastMousePosition = Input.mousePosition;

            }
            else
            {
                if (fd.force > 100)
                {
                    fd.force -= 500 * Time.deltaTime;
                }
                else
                {
                    fd.isTrue = false;
                    fd.force = 100f;
                }
                

            }

        }
        
    }
}

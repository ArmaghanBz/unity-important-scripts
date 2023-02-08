using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorChange : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere1;
    public GameObject sphere2;

    private SpringJoint spring1;
    private SpringJoint spring2;

    void Start()
    {
        spring1 = sphere1.GetComponent<SpringJoint>();
        spring2 = sphere2.GetComponent<SpringJoint>();  
    }

    void Update()
    {
        spring1.connectedAnchor = cube.transform.position;
        spring2.connectedAnchor = cube.transform.position;
    }
}

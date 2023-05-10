using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stacking : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;
    //
    [SerializeField] private float _speed;
    //
    List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;
    public Transform stackingPoint;

   
    private void Start()
    {
       
    }
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("picked"))
        {
            _cubeList.Add(other.gameObject);
            if (_cubeList.Count == 1)
            {
                //_firstCubePos = GetComponent<MeshRenderer>().bounds.max;
                _firstCubePos = stackingPoint.position;
                _currentCubePos = new Vector3(other.transform.position.x, _firstCubePos.y, other.transform.position.z);
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, stackingPoint.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.transform.SetParent(transform);
                other.gameObject.GetComponent<cubes>().UpdateCubePosition(stackingPoint.transform, true);
                other.tag = "onpicked";
            }
            else if (_cubeList.Count > 1)
            {
                other.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(other.transform.position.x, other.gameObject.transform.position.y + 0.3f, other.transform.position.z);
                other.gameObject.GetComponent<cubes>().UpdateCubePosition(_cubeList[_cubeListIndexCounter].transform, true);
                other.gameObject.transform.SetParent(transform);
                _cubeListIndexCounter++;
                other.tag = "onpicked";
            }
            
        }

   
    }
}

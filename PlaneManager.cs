using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    public GameObject[] planes;
    public int currentPlaneIndex = 0;
    public int coinsCollected = 0;
    public bool isLeftRight;

    public CountDownUI countdownUI;

    public float flyingSpeed = 50f;
    public float flyingDistance = 1000f;

    public bool isFlying = false;
    private float currentFlyingDistance = 0f;
    private float lateralSpeed;

    public int PlaneCapacity = 0;


    Dictionary<int, int> capacityToPlaneIndex = new Dictionary<int, int>()
    {
        { 50, 0 },
        { 100, 1 },
        { 150, 2 },
        { 200, 3 },
        { 250, 4 },
        { 300, 5 },
        { 350, 6 }
    };


    void Start()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            planes[i].SetActive(i == 0);
        }
        isLeftRight = true;
        countdownUI = FindObjectOfType<CountDownUI>();
    }

    void Update()
    {
        //if (coinsCollected >= 2)
        //{
        //    currentPlaneIndex++;
        //    if (currentPlaneIndex >= planes.Length)
        //    {
        //        currentPlaneIndex = planes.Length - 1;
        //    }
        //    planes[currentPlaneIndex].SetActive(true);
        //    planes[currentPlaneIndex - 1].SetActive(false);
        //    coinsCollected = 0;
        //}
        //else if (coinsCollected < 0)
        //{
        //    currentPlaneIndex--;
        //    if (currentPlaneIndex < 0)
        //    {
        //        currentPlaneIndex = 0;
        //    }
        //    planes[currentPlaneIndex].SetActive(true);
        //    planes[(currentPlaneIndex + 1) % planes.Length].SetActive(false);
        //    coinsCollected = 0;
        //}
        //if(PlaneCapacity > 50 && PlaneCapacity <= 100)
        //{
        //    planes[1].SetActive(true);
        //    planes[0].SetActive(false);
        //}
        //else if(PlaneCapacity >100 && PlaneCapacity <= 150)
        //{
        //    planes[1].SetActive(false);
        //    planes[2].SetActive(true);
        //}
        //else if (PlaneCapacity > 150 && PlaneCapacity <= 200)
        //{
        //    planes[2].SetActive(false);
        //    planes[3].SetActive(true);
        //}
        //else if (PlaneCapacity > 200 && PlaneCapacity <= 250)
        //{
        //    planes[3].SetActive(false);
        //    planes[4].SetActive(true);
        //}
        //else if (PlaneCapacity > 250 && PlaneCapacity <= 300)
        //{
        //    planes[4].SetActive(false);
        //    planes[5].SetActive(true);
        //}
        //else if (PlaneCapacity > 300 && PlaneCapacity <= 350)
        //{
        //    planes[5].SetActive(false);
        //    planes[6].SetActive(true);
        //}

        if (isFlying)
        {
            if (Input.GetMouseButton(0))
            {
                float inputX = Input.GetAxis("Mouse X");
                Vector3 position = transform.position;
                position.x += inputX * flyingSpeed * Time.deltaTime;
                position.x = Mathf.Clamp(position.x, -2.36f, 2.36f);
                transform.position = position;
                float tiltAngle = -inputX * 45f;
                Quaternion targetTilt = Quaternion.Euler(0f, 0f, tiltAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetTilt, 0.1f);
                transform.Translate(Vector3.forward * flyingSpeed * Time.deltaTime);

                currentFlyingDistance += flyingSpeed * Time.deltaTime;
                if (currentFlyingDistance >= flyingDistance)
                {
                    isFlying = false;
                    currentFlyingDistance = 0f;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsCollected++;
        }
        else if (other.gameObject.CompareTag("wall"))
        {
            GateValues gateValues = other.gameObject.GetComponent<GateValues>();
            PlaneCapacity += gateValues.value;
            foreach (var capacity in capacityToPlaneIndex.Keys)
            {
                if (PlaneCapacity <= capacity)
                {
                    int planeIndex = capacityToPlaneIndex[capacity];
                    for (int i = 0; i < planes.Length; i++)
                    {
                        planes[i].SetActive(i == planeIndex);
                    }
                    break;
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.CompareTag("greenWall"))
        //{
        //    print("Green Hit");
        //    coinsCollected += 2;
        //    other.GetComponent<Collider>().enabled = false; 
        //}
        //else if (other.gameObject.CompareTag("redWall"))
        //{
        //    print("Red Hit");
        //    coinsCollected -= 1;
        //    other.GetComponent<Collider>().enabled = false;

        //}
        if (other.gameObject.CompareTag("endPoint"))
        {
            isLeftRight = false;
            countdownUI.StartCountdown();
            StartCoroutine(StartFlyingAfterCountdown());
            Destroy(other.gameObject);
        }
    }
    IEnumerator StartFlyingAfterCountdown()
    {
        yield return new WaitForSeconds(countdownUI.countdownTime);

        isFlying = true;
    }


}

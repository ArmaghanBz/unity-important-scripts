using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlaneManager : MonoBehaviour
{
    public GameObject[] planes;
    public GameObject fuelBarCanvas;
    public int currentPlaneIndex = 0;
    public int coinsCollected = 0;
    public bool isLeftRight;
    public int score,highScore;

    public CountDownUI countdownUI;
    public GameObject levelDone;

    
    public float flyingSpeed = 50f;
    float flyingDistance = 2000f;

    public bool isFlying = false;
    private float currentFlyingDistance = 0f;
    private float lateralSpeed;
    private Text scoreText;

    public int PlaneCapacity = 0;

    public FuelBar fuelbar;


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
        levelDone.SetActive(false);
    }

    void Update()
    {

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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("endState"))
        {
            print("End");
        }
        else if (collision.gameObject.CompareTag("barrier"))
        {
            Animator barrierAnimator = collision.gameObject.GetComponent<Animator>();
            if (barrierAnimator != null)
            {
                barrierAnimator.enabled = true;
            }

            PlaneCapacity -= 50;
        }
        else if (collision.gameObject.CompareTag("road"))
        {
            isLeftRight = false;
            isFlying= false;
            print("Level Complete");
            levelDone.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("batteries"))
        {
            fuelbar.SetHealth(0.1);
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("wall"))
        {
            GateValues gateValues = other.gameObject.GetComponent<GateValues>();
            PlaneCapacity += gateValues.value;
            score += gateValues.value;
            foreach (var capacity in capacityToPlaneIndex.Keys)
            {
                if (PlaneCapacity <= capacity)
                {
                    int planeIndex = capacityToPlaneIndex[capacity];
                    for (int i = 0; i < planes.Length; i++)
                    {
                        planes[i].SetActive(i == planeIndex);
                        //GetComponent<Rigidbody>().drag = planes[planeIndex].GetComponent<PlaneDrag>().dragValue;
                    }
                    break;
                }
            }
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("endPoint"))
        {
            isLeftRight = false;
            countdownUI.StartCountdown();
            StartCoroutine(StartFlyingAfterCountdown());
            Destroy(other.gameObject);
            GetComponent<Rigidbody>().drag = fuelbar.slider.value;
            fuelBarCanvas.SetActive(false);
        }
    }
    IEnumerator StartFlyingAfterCountdown()
    {
        yield return new WaitForSeconds(countdownUI.countdownTime);

        isFlying = true;
    }


}

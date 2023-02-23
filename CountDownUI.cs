using UnityEngine;
using UnityEngine.UI;

public class CountDownUI : MonoBehaviour
{
    public float countdownTime = 5f;
    private float currentTime;
    private bool isCountingDown = false;
    private Text countdownText;
    public PlaneManager obj;

    private void Start()
    {
        countdownText = GetComponent<Text>();
        countdownText.text = "";
        obj = FindObjectOfType<PlaneManager>(); 
    }

    private void Update()
    {
        if (isCountingDown)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = "" + Mathf.RoundToInt(currentTime);
            if (currentTime <= 0f)
            {
                isCountingDown = false;
                obj.isLeftRight= true;
               
            }
        }
    }

    public void StartCountdown()
    {
        isCountingDown = true;
        currentTime = countdownTime;
        countdownText.text = "" + Mathf.RoundToInt(currentTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 5f;
    public bool timerIsRunning;
    public TextMeshProUGUI timeText;
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining >= 0) {
                timeRemaining -= Time.deltaTime;

                timeText.text = Mathf.RoundToInt(timeRemaining).ToString();
            }
            else
            {
                GameProcess.goToFightScene();
                timerIsRunning = false;
            }

        }
    }
}

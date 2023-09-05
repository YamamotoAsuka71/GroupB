using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public int countdownMinutes = 1;//•ª
    private float countdownSeconds;//•b
    public Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;
    }

    void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
        //GetComponent<TextMeshProUGUI>().text = "time:" + Timer.ToString("f2");
        if (countdownSeconds <= 0)
        {
            // 0•b‚É‚È‚Á‚½‚Æ‚«‚Ìˆ—
        }
    }
}
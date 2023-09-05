using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int countdownMinutes = 3;//  ï™
    private float countdownSeconds;//Å@ïb
    private Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"3\:00");

        if (countdownSeconds <= 0)
        {
            // 0ïbÇ…Ç»Ç¡ÇΩÇ∆Ç´ÇÃèàóù
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    int countdownMinutes = 1;//•ª
    private float countdownSeconds;//•b
    public Text timeText;
    public GameObject text;
    TextMeshProUGUI Text;


    private void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;//‚±‚±‚Å‚P•ªi‚U‚O•bj‚ª‚R‰ñ‚Å‚R•ª‚ğŒvZ‚µ‚Ä‚¢‚é
        Text = text.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        

@@@@//0•b‚É‚È‚Á‚½‚Æ‚«‚Ìˆ—
        if (countdownSeconds <= 0)
        {
            Time.timeScale = 0;
            Text.text = "<color=#ff0000>GAME CLEAR!!";
        }
        else
        {
            countdownSeconds -= Time.deltaTime;
        }
        //‚±‚±‚Å2:30‚İ‚½‚¢‚È•\¦‚É‚µ‚Ä‚¢‚é

        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
    }
}
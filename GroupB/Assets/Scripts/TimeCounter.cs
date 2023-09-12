using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public int countdownMinutes = 3;//•ª
    private float countdownSeconds;//•b
    public Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;//‚±‚±‚Å‚P•ªi‚U‚O•bj‚ª‚R‰ñ‚Å‚R•ª‚ğŒvZ‚µ‚Ä‚¢‚é
    }

    void Update()
    {
        //‚±‚±‚Å2:30‚İ‚½‚¢‚È•\¦‚É‚µ‚Ä‚¢‚é
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");

@@@@//0•b‚É‚È‚Á‚½‚Æ‚«‚Ìˆ—
        if (countdownSeconds <= 0)
        {
            //0•b‚É‚È‚Á‚½‚çÁ‚·
            Destroy(timeText);
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public int countdownMinutes = 3;//分
    private float countdownSeconds;//秒
    public Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;//ここで１分（６０秒）が３回で３分を計算している
    }

    void Update()
    {
        //ここで2:30みたいな表示にしている
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");

　　　　//0秒になったときの処理
        if (countdownSeconds <= 0)
        {
            //0秒になったら消す
            Destroy(timeText);
        }
    }
}
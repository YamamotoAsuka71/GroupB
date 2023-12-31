using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    int countdownMinutes = 1;//分
    private float countdownSeconds;//秒
    public Text timeText;
    public GameObject text;
    TextMeshProUGUI Text;


    private void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;//ここで１分（６０秒）が３回で３分を計算している
        Text = text.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        

　　　　//0秒になったときの処理
        if (countdownSeconds <= 0)
        {
            Time.timeScale = 0;
            Text.text = "<color=#ff0000>GAME CLEAR!!";
        }
        else
        {
            countdownSeconds -= Time.deltaTime;
        }
        //ここで2:30みたいな表示にしている

        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
    }
}
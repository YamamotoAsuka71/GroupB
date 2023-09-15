using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    int countdownMinutes = 1;//��
    private float countdownSeconds;//�b
    public Text timeText;
    public GameObject text;
    TextMeshProUGUI Text;


    private void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;//�����łP���i�U�O�b�j���R��łR�����v�Z���Ă���
        Text = text.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        

�@�@�@�@//0�b�ɂȂ����Ƃ��̏���
        if (countdownSeconds <= 0)
        {
            Time.timeScale = 0;
            Text.text = "<color=#ff0000>GAME CLEAR!!";
        }
        else
        {
            countdownSeconds -= Time.deltaTime;
        }
        //������2:30�݂����ȕ\���ɂ��Ă���

        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");
    }
}
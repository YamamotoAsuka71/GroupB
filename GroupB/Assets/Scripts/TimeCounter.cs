using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    int countdownMinutes = 2;//��
    private float countdownSeconds;//�b
    public Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;//�����łP���i�U�O�b�j���R��łR�����v�Z���Ă���
    }

    void Update()
    {
        

�@�@�@�@//0�b�ɂȂ����Ƃ��̏���
        if (countdownSeconds <= 0)
        {
            
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
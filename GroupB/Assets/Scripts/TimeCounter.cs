using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public int countdownMinutes = 3;//��
    private float countdownSeconds;//�b
    public Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;//�����łP���i�U�O�b�j���R��łR�����v�Z���Ă���
    }

    void Update()
    {
        //������2:30�݂����ȕ\���ɂ��Ă���
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");

�@�@�@�@//0�b�ɂȂ����Ƃ��̏���
        if (countdownSeconds <= 0)
        {
            //0�b�ɂȂ��������
            Destroy(timeText);
        }
    }
}